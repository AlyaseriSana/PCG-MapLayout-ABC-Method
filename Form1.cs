using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapABC
{
    public partial class Form1 : Form
    {
        Room room = new Room();
        static int step1 = 50;
        static int step2 = 50;
        static int ImgW = 10; // the size of the map
        static int ImgH = 10; // the size of the map
        static int NumberOfShapTypes = 14;
        static int MapArea = ImgW * ImgH;
        static int PubSize = 600;
        static int Maxloop = 200;
        private const int MaxIterationsWithoutImprovement = 5;
        private static readonly Random RandomGenerator = new Random();
        private static readonly Random r = new System.Random();
        static int MutationRate = (int)(0.05 * (ImgH * ImgW));  // Mutation rate should be 0.05 as the first part 
        Bee employeeB = new Bee();
        Bee employPartner = new Bee();
        Bee onlookerB = new Bee();
        Bee scoutB = new Bee();
        Bee bestBee = new Bee();
        
        bool foodsource = false;
        
        List<Bee> BeePopulation = new List<Bee>(PubSize);   // save all the Bees which has to be find the partner
        

      
      //ExcelFile excelTest = new ExcelFile(@"C:\Users\ncd2763\Documents\Data\ABS\test1.xlsx", 1);
        int row = 2;
        int col = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //excelTest.excelclear();
            DoABC();
          // excelTest.ExcelSave();
         // excelTest.excelClose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            int A = room.width + 2;
            bestBee.DrawGraph(e, A, step1, step2, ImgW, ImgH);
            bestBee.OnPaint(e);
            string message1 = "List Of Nodes ";
            foreach (TreeNode node in bestBee.ListOfNodeResult)
                message1 += " + " + node.Data.ToString();
             MessageBox.Show(message1);
            message1 = " ";
            foreach (TreeNode node in bestBee.nodes)
                message1 += " + " + node.Size.ToString();
            MessageBox.Show(message1);
            
        }

        void DoABC()
        {
            int k = 0;
            double MaxFitnees;
            int bestBeeIndex;

            BeePopulation = GenerateRandomPopulation();
            


            // Food source information
            do
            {
                if (Maxloop < 1)
                    break;

                // On Employee Phase  
                DoEmployeePhase(BeePopulation);


                // Onlooker Phase
                DoOnlookerBeePhase(BeePopulation);
                // On Scout Phase
                DoScoutBeePhase(BeePopulation);

                MaxFitnees = getMaxFitness(BeePopulation);
                bestBeeIndex = BeeBestFitnessIndex(BeePopulation);
                bestBee = BeePopulation[bestBeeIndex];
                
               // Point D1 = bestBee.ListOfNodeResult[bestBee.ListOfNodeResult.Count - 1].Data;
               // Point D2 = bestBee.TraceNode[bestBee.TraceNode.Count - 1].Data;
               // System.Diagnostics.Debug.WriteLine( k + " best is "  + bestBee.FitnessValue + " the scor is " + 
                 //   bestBee.CalculateThePinaltyScoreStart() + " + " + bestBee.CalculateThePinaltyScoreEnd());
                
               
               
                k++;
               
              // excelTest.writeXcelsheet(row, col, k.ToString());

              // excelTest.writeXcelsheet(row, col + 2, MaxFitnees.ToString());
                row++;

            } while (k < Maxloop);
            if (Maxloop < 1)
            {
                bestBeeIndex = r.Next(0, PubSize);
                System.Diagnostics.Debug.WriteLine("the only one " + bestBeeIndex );
                bestBee = BeePopulation[bestBeeIndex];
            }  
                
            


        }

        void DoEmployeePhase(List<Bee> EmployeePhase)
        {
            
            int rEbeeP = 0;//random number to get the random map 
            
            double EbeeFitness = 0;
            double EbeePartner = 0;
            double UpdateFitness = 0;
          

            for (int iDance = 0; iDance < PubSize; iDance++)
            {
                // employee phase ( get maximum dance)

                foodsource = false;
                int limit = 0;
                while (!foodsource & (limit < PubSize))
                {
                    foodsource = true;
                    rEbeeP = r.Next(0, PubSize);  // random number to choose a best map as food source to employee Bee

                    if (iDance == rEbeeP)
                        foodsource = false;
                    limit++;
                    employeeB = EmployeePhase[iDance];
                    employPartner = EmployeePhase[rEbeeP];
                    EbeeFitness = employeeB.getFitness();
                    EbeePartner = employPartner.getFitness();
                    if (EbeePartner < EbeeFitness)
                        foodsource = false;


                }
                doUpdatBee(employeeB, employPartner);
                
               
                UpdateFitness = employeeB.getFitness();
                //System.Diagnostics.Debug.WriteLine("k is " + k + " the orginal fitness is " + EbeeFitness + " new fitness is "+ UpdateFitness + " track no is " + employeeB.MapNo);
                if (UpdateFitness > EbeeFitness)
                {
                    EmployeePhase[iDance].IterationsWithoutImprovement = 0;
                    EmployeePhase[iDance] = employeeB;
                    EmployeePhase[iDance].FitnessValue = EmployeePhase[iDance].getFitness();
                }
                else
                    EmployeePhase[iDance].IterationsWithoutImprovement++;



            }   //end of dance loop 

        }

        void DoOnlookerBeePhase(List<Bee> population)
        {
            double EbeeFitness = 0;
            double EbeePartner = 0;



            for (int iDance = 0; iDance < PubSize; iDance++)
            {
                foodsource = false;
                int selectIndex = 0;
                int limit = 0;
                Bee LookerBee = new Bee();
                Bee EmployBee = new Bee();
                while (!foodsource & (limit < MaxIterationsWithoutImprovement))
                {
                    foodsource = true;
                    selectIndex = SelectionBee(population);  // random number to choose a best map as food source to locaker Bee
                    if (iDance == selectIndex)
                        foodsource = false;
                    limit++;
                    LookerBee = population[selectIndex];
                    EbeePartner = LookerBee.getFitness();
                    EmployBee = population[iDance];
                    EbeeFitness = EmployBee.getFitness();
                    if (EbeePartner < EbeeFitness)
                        foodsource = false;


                }
                //System.Diagnostics.Debug.WriteLine("the employee fitness " + EbeePartner + " and the partner is " + EbeeFitness);
                population[iDance].IterationsWithoutImprovement = limit;                             
                doUpdatBee(EmployBee,LookerBee );
                double UpdateFitness = EmployBee.FitnessValue;
               // System.Diagnostics.Debug.WriteLine("k is " + iDance + " the orginal fitness is " + EbeeFitness + " new fitness is "+  UpdateFitness);
                if (UpdateFitness > EbeeFitness)
                {
                    population[iDance].IterationsWithoutImprovement = 0;
                    population[iDance] = EmployBee;
                }
                else
                    population[iDance].IterationsWithoutImprovement++;


            } // end of looker phase 
        }

        int SelectionBee(List<Bee> population)
        {
            double totalFitness = population.Sum(n => n.FitnessValue);
            List<Bee> SortPopulation = population.OrderByDescending(bee => bee.FitnessValue).ToList();

            var cumulativeProbabilities = new List<double>(population.Count);
            double cumulativeTotal = 0.0;

            foreach (var individual in population)
            {
                double proportion = individual.FitnessValue / totalFitness;
                cumulativeTotal += proportion;
                cumulativeProbabilities.Add(cumulativeTotal);
            }

            double selectiveValue = r.NextDouble();
            int selectedIndex = 0;

            for (int i = 0; i < cumulativeProbabilities.Count; i++)
            {
                //System.Diagnostics.Debug.WriteLine(" i= " + i + " cumulativeProbabilities[i] = " + cumulativeProbabilities[i] + " selectiveValue = " + selectiveValue);
                if (selectiveValue < cumulativeProbabilities[i])
                {
                    selectedIndex = i;
                    break;
                }
            }

            return selectedIndex;
        }

        private static void DoScoutBeePhase(List<Bee> population)
        {
            foreach (Bee solution in population)
            {
                if (solution.IterationsWithoutImprovement >= MaxIterationsWithoutImprovement)
                {
                    Bee scoutSolution = new Bee(NumberOfShapTypes, ImgW, ImgH);
                    if (scoutSolution.getFitness() > solution.getFitness())
                      {
                        solution.nodes = scoutSolution.nodes;
                        solution.FitnessValue = scoutSolution.getFitness();

                        solution.IterationsWithoutImprovement = 0;
                      }
                }
               
              
            }
        }



        private static List<Bee> GenerateRandomPopulation()
        {
            // Generate a random population of trees for initialization
            List<Bee> population = new List<Bee>();

            for (int i = 0; i < PubSize; i++)
            {
                Bee NT = new Bee(NumberOfShapTypes, ImgW, ImgH);
                population.Add(NT);
            }

            return population;
        }



       void doUpdatBee(Bee OldBee, Bee FoodSourceBee) // doUpdatemployBee(employeeB, employPartner, EmployeePhase[iDance]);
        {
            //System.Diagnostics.Debug.WriteLine(" before update " + OldBee.getFitness());
            System.Random GenNo = new System.Random();
            HashSet<int> GenNmbers = new HashSet<int>();
            while (GenNmbers.Count < MutationRate)
            {
                int GenNo1 = GenNo.Next(1, OldBee.nodes.Count());
                GenNmbers.Add(GenNo1);


            }
          
           
            foreach (int genNumber in GenNmbers)
            {
                //System.Diagnostics.Debug.WriteLine(" GenNo =" + genNumber + " the first " + OldBee.nodes[genNumber].Size + " the other " + FoodSourceBee.nodes[genNumber].Size);
                TreeNode TempNode = OldBee.nodes[genNumber];
                TreeNode NewUpdateNode = FoodSourceBee.nodes[genNumber];
                TempNode.Size = NewUpdateNode.Size;
              
                OldBee.nodes[genNumber] = TempNode;
                //System.Diagnostics.Debug.WriteLine(" GenNo =" + genNumber + " the first AFTER " + OldBee.nodes[genNumber].Size + " the other " + FoodSourceBee.nodes[genNumber].Size);

            }
            
            
            OldBee.FitnessValue = OldBee.getFitness();

            //System.Diagnostics.Debug.WriteLine(" the new fitness only " + OldBee.FitnessValue); 

        }

        



        double getMaxFitness(List<Bee> BeeList)
        {
            double[] WList = new double[PubSize];
            int i = 0;
            foreach (Bee aBee in BeeList)
            {
                WList[i] = aBee.getFitness();
                aBee.FitnessValue = aBee.getFitness();
                i++;
            }

            return WList.Max();
        }

        int BeeBestFitnessIndex(List<Bee> position)
        {
            double fittedValue = 0;

            int fitted = 0;
            for (int i = 0; i < position.Count(); i++)
            {
                position[i].FitnessValue = position[i].getFitness();
                if (position[i].FitnessValue > fittedValue)
                {
                    fittedValue = position[i].FitnessValue;
                    fitted = i;
                }

            }
            return fitted; // Return the index


        }


    }
}
