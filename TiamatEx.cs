using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;


namespace Tiamat
{
    class TiamatEx
    {
        // most of the program is in here

        public static void TiamatExecute(string[] UI, Patient patient, Course course, StructureSet structureset, ExternalPlanSetup plan, User user, TextBox outbox, ProgressBar progbar)
        {
            Task internalcollisioncheck = Task.CompletedTask;
           

             //MessageBox.Show("Start of GUI Execute event method.");

            patient.BeginModifications();

            //========================================================================================================================================================================
            // All this is for adding a new course and plan. won't use this for now
            // Idea is that the Dosimitrists will make a course and plan, bring in the CT image, contour the organs/structures, choose a reference point for the structure set, and then run Tiamat
            //course.AddExternalPlanSetup(structureSet);

            ////need a way to identify this plan we just added. Normally this script will be run in a empty course, but it might not be
            //if (course.PlanSetups.Count() > 1)
            //{
            //    var be = course.PlanSetups.Where(n => n.Beams.Count().Equals(0)).ToList();
            //    be.First().Id = "Autoplan";
            //}
            //else
            //{
            //    course.PlanSetups.First().Id = "Autoplan";
            //}

            //var bea = course.PlanSetups.Where(p => p.Id.Equals("Autoplan")).ToList();
            //ExternalPlanSetup plan = (ExternalPlanSetup)bea.First();  //this is the plan we added and that we will be modifying and working with

            // hopefully it uses a reference point that is already there
            // check plan and course names
            //==================================================================================================================================================================================

            // create the beam configuration via the AddBeams method, which parses through the Treatment site, laterality, and technique to create a standarized beam confoguration based on department standards
            // AddBeams does not return a plan or anything else, it adds beams to the given plan, using the various ESAPI add beam methods
            // UI O - Linac
            // UI 1 - Treatment Technique
            // UI 2 - Treatment Site
            // UI 3 - Laterality
            // UI 4 - SetupBeams
            // UI 5 - Optimize
            // UI 6 - Rapidplan
            // UI 7 - DoseCalc
            // UI 8 - Acuros Algo
            // UI 9 - Trade-off analysis
            // UI 10 - QA plan
            // UI 11 - Optimization Objective Set

            //List<string> calcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonVolumeDose);
            //string calcmodels = "Calculation models for Photon Volume Dose";
            //foreach (string str in calcmodellist)
            //{
            //    calcmodels = calcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(calcmodels);


            //List<string> picalcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonIMRTOptimization);
            //string picalcmodels = "Calculation models for Photon IMRT Optimization";
            //foreach (string str in picalcmodellist)
            //{
            //    picalcmodels = picalcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(picalcmodels);

            //List<string> dvhcalcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.DVHEstimation);
            //string dvhcalcmodels = "Calculation models for DVH estimation";
            //foreach (string str in dvhcalcmodellist)
            //{
            //    dvhcalcmodels = dvhcalcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(dvhcalcmodels);

            //List<string> VMATcalcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonVMATOptimization);
            //string VMATcalcmodels = "Calculation models for Photon VMAT Optimization";
            //foreach (string str in VMATcalcmodellist)
            //{
            //    VMATcalcmodels = VMATcalcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(VMATcalcmodels);

            //List<string> SRScalcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonSRSDose);
            //string SRScalcmodels = "Calculation models for Photon SRS Dose";
            //foreach (string str in SRScalcmodellist)
            //{
            //    SRScalcmodels = SRScalcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(SRScalcmodels);

            //List<string> lcalcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonLeafMotions);
            //string lcalcmodels = "Calculation models for Photon Leaf Motions";
            //foreach (string str in lcalcmodellist)
            //{
            //    lcalcmodels = lcalcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(lcalcmodels);


            //List<string> phcalcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonOptimization);
            //string phcalcmodels = "Calculation models for Photon Optimization?";
            //foreach (string str in phcalcmodellist)
            //{
            //    phcalcmodels = phcalcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(phcalcmodels);

            //List<string> calcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonVolumeDose);
            //string calcmodels = "Calculation models for Photon Volume Dose";
            //foreach (string str in calcmodellist)
            //{
            //    calcmodels = calcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(calcmodels);

           // MessageBox.Show("Trig 0.2");
            progbar.Visible = true;
            progbar.Style = ProgressBarStyle.Marquee;
            progbar.MarqueeAnimationSpeed = 150;
            //MessageBox.Show("Trig 0.3");

            bool SRS;
            if (UI[1].Contains("SRS"))
            {
                SRS = true;
            }
            else
            {
                SRS = false;
            }

            if (UI[2] == "NA")
            {
               // MessageBox.Show("Trig 1");
                //This part let's us do stuff if the user does not want to add treatment beams, by selecting "NA" as the treatment site
                //this allows the user to use Tiamat to just add imaging beams or create a QA plan. That way we don't need to make separate programs to do that.
                if (UI[4] == "SetupBeams - Y")
                {
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Generating imaging setup beams...");

                    TiamatMethods.AddGenericImagingBeams(UI, plan);

                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Finished adding imaging setup beams.");
                }

                //if (UI[10] == "QA - Y")
                //{
                //    //MessageBox.Show("Trig 2");
                //    try
                //    {
                //        outbox.AppendText(Environment.NewLine);
                //        outbox.AppendText("Creating QA plan in separate course...");

                //        TiamatMethods.MakeQAPlan(patient, plan, UI[0]);

                //        //MessageBox.Show("Trig 5");
                //        outbox.AppendText(Environment.NewLine);
                //        outbox.AppendText("QA plan ready.");
                //    }
                //    catch(Exception e)
                //    {
                //        MessageBox.Show("QA plan creation error: \n" + e.ToString() + "\n" + e.StackTrace + "\n" + e.InnerException + "\n" + e.TargetSite );
                //    }
                //}
            }


            if (UI[2] != "NA")
            {
                if (UI[4] == "SetupBeams - Y")
                {
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Generating treatment beams and imaging setup beams...");
                }
                else
                {
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Generating treatment beams ...");
                }

                TiamatMethods.AddBeams(UI, plan);

                if (UI[4] == "SetupBeams - Y")
                {
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Finished adding treatment beams and imaging setup beams.");
                }
                else
                {
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Finished adding treatment beams.");
                }


                //internalcollisioncheck = TiamatMethods.TiamatCollisionCheckExecute(plan, structureset, SRS, outbox, UI[2]);


                //MessageBox.Show("internalcollisioncheck : " + internalcollisioncheck.ToString());
                //MessageBox.Show("internalcollisioncheck status: " + internalcollisioncheck.Status.ToString());

                //Think about structure manipulations, automatically adding margins to structures

                //making DRRs

                if (UI[5] == "Optimize - Y")
                {
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Starting Plan Optimization...");

                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Clearing existing optimization objectives...");
                    foreach (VMS.TPS.Common.Model.API.OptimizationObjective obj in plan.OptimizationSetup.Objectives)
                    {
                        plan.OptimizationSetup.RemoveObjective(obj);
                    }
                    //This seems to be working??

                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("**Objectives list size: " + plan.OptimizationSetup.Objectives.Count());

                    if (UI[6] == "Rapid - Y")
                    {
                        outbox.AppendText(Environment.NewLine);
                        outbox.AppendText("Calling Rapidplan model for optimization...");
                        //need to build this out eventually. No point until the Rapidplan models are built for V16.1


                    }

                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Constructing Optimization Objectives based on given structures...");
                    // breaking somewhere after this. think we just need to add optimization objectives for H&N

                    Tiamat.OptimizationObjective[] objectives = Tiamat.TiamatMethods.MakeOptimizationObjectives(UI[2], UI[1], UI[0], UI[3], UI[11]);

                    for (int opt = 0; opt < objectives.Length; opt++)
                    {
                        Structure strtemp = plan.StructureSet.Structures.First();
                        foreach (Structure str in plan.StructureSet.Structures)
                        {
                            if (str.Id == objectives[opt].StructureID)
                            {
                                strtemp = str;

                                if (objectives[opt].ObjectiveType == "point")
                                {
                                    plan.OptimizationSetup.AddPointObjective(strtemp, objectives[opt].ObjectiveOperator, objectives[opt].DoseValue, objectives[opt].Volume, objectives[opt].Priority);
                                }
                                else if (objectives[opt].ObjectiveType == "mean")
                                {
                                    plan.OptimizationSetup.AddMeanDoseObjective(strtemp, objectives[opt].DoseValue, objectives[opt].Priority);
                                }
                            }
                        }
                    }
                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText(objectives.Length + " Optimization Objectives made for structures present in plan.");


                    if (UI[1].Contains("VMAT"))
                    {
                        outbox.AppendText(Environment.NewLine);
                        outbox.AppendText("Calling VMAT Optimization Algorithim...");

                        OptimizerResult OptResult = plan.OptimizeVMAT();

                        if (OptResult.Success)
                        {
                            outbox.AppendText(Environment.NewLine);
                            outbox.AppendText("VMAT Optimization Succesful!");
                        }

                    }
                    else if (UI[1].Contains("IMRT"))
                    {
                        outbox.AppendText(Environment.NewLine);
                        outbox.AppendText("Calling IMRT Optimization Algorithim...");

                        // need to figure this out exactly


                        OptimizerResult OptResult = plan.Optimize();
                        if (OptResult.Success)
                        {
                            outbox.AppendText(Environment.NewLine);
                            outbox.AppendText("IMRT Optimization Succesful!");
                        }

                        //Leaf Motion calculation

                        if (UI[0] == "Truebeam")
                        {
                            SmartLMCOptions smoptions = new SmartLMCOptions(false, false);
                            outbox.AppendText(Environment.NewLine);
                            outbox.AppendText("Calling Smart LMC Leaf Motion Algorithim...");
                            CalculationResult smLMcalcResult = plan.CalculateLeafMotions();
                            if (smLMcalcResult.Success)
                            {
                                outbox.AppendText(Environment.NewLine);
                                outbox.AppendText("Leaf Motion Calculation Successful!");
                            }
                        }
                        else
                        {
                            LMCVOptions options = new LMCVOptions(false);
                            outbox.AppendText(Environment.NewLine);
                            outbox.AppendText("Calling Varian Leaf Motion Algorithim...");
                            CalculationResult LMcalcResult = plan.CalculateLeafMotions(options);
                            if (LMcalcResult.Success)
                            {
                                outbox.AppendText(Environment.NewLine);
                                outbox.AppendText("Leaf Motion Calculation Successful!");
                            }
                        }




                    }
                }

                if (UI[7] == "DoseCalc - Y")
                {
                    //AAA_1610
                    //AcurosXB__1610
                    //CDC_1610
                    string calctype = null;
                    string dosealgo = null;

                    if (UI[1].Contains("SRS"))
                    {
                        plan.SetCalculationModel(CalculationType.PhotonSRSDose, "CDC_1610");
                        calctype = "Photon SRS Dose";
                        dosealgo = "CDC_1610";
                    }
                    else
                    {
                        if (UI[8] == "Acuros - N")
                        {
                            plan.SetCalculationModel(CalculationType.PhotonVolumeDose, "AAA_1610");
                            calctype = "Photon Volume Dose";
                            dosealgo = "AAA_1610";
                        }
                        else if (UI[8] == "Acuros - Y")
                        {
                            plan.SetCalculationModel(CalculationType.PhotonVolumeDose, "AcurosXB_1610");
                            calctype = "Photon SRS Dose";
                            dosealgo = "AcurosXB_1610";
                        }
                    }

                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Starting Dose Calculation, Calculation type: " + calctype + ", Algorithim: " + dosealgo);
                    CalculationResult DcalcResult = plan.CalculateDose();

                    if (DcalcResult.Success)
                    {
                        outbox.AppendText(Environment.NewLine);
                        outbox.AppendText("Dose Calculation Successful!");
                    }

                    outbox.AppendText(Environment.NewLine);
                    outbox.AppendText("Launching auotmatic Plancheck on separate thread. PDF report will appear when done.");
                    TiamatMethods.TiamatPlancheckExecute(plan, patient, user, UI[3]);
                }

                //if (UI[10] == "QA - Y")
                //{
                //    try
                //    {
                //        outbox.AppendText(Environment.NewLine);
                //        outbox.AppendText("Creating QA plan in separate course...");

                //        TiamatMethods.MakeQAPlan(patient, plan, UI[0]);

                //        //MessageBox.Show("Trig 5");
                //        outbox.AppendText(Environment.NewLine);
                //        outbox.AppendText("QA plan ready.");
                //    }
                //    catch (Exception e)
                //    {
                //        MessageBox.Show("QA plan creation error: \n" + e.ToString() + "\n" + e.StackTrace + "\n" + e.InnerException + "\n" + e.TargetSite);
                //    }
                //}

                if (UI[9] == "Tradeoff - Y")
                {
                    MessageBox.Show("This is a placeholder for using tradeoff exploration with a Multi Criteria Optimizer. Not built yet"); 
                }

            } //end of UI[2] != NA

            //List<string> calcmodellist = (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonVolumeDose);
            //string calcmodels = "Calculation models for Photon Volume Dose";
            //foreach (string str in calcmodellist)
            //{
            //    calcmodels = calcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(calcmodels);

            // call a fast collision check to run on a separate thread concurrently after all beams made

            // Dose Calculation
            //List<string> calcmodellist =  (List<string>)plan.GetModelsForCalculationType(CalculationType.PhotonVolumeDose);
            //string calcmodels = "Calculation models for Photon Volume Dose";
            //foreach(string str in calcmodellist)
            //{
            //    calcmodels = calcmodels + "\n\n" + str + "\n";
            //}
            //MessageBox.Show(calcmodels);

            //plan.SetCalculationModel(CalculationType.PhotonVolumeDose, "AAA");

            //CalculationResult DcalcResult = plan.CalculateDose();

            //if (DcalcResult.Success)
            //{
            //    MessageBox.Show("Dose Calculation Successful!");
            //}

            // Tiamat.TiamatMethods.TiamatPlancheckExecute(plan, patient, user);








            //// possibly run the DVH check script here?

            ////trade-off Exploration?

            ////plan.TradeoffExplorationContext.TradeoffStructureCandidates

            //// Important note: maybe we do not run the Dose Objective Check script in full, but we can steal code from it to do some analysis here
            //// For analysis of both Optimizer results and trade off exploration

            //plan.TradeoffExplorationContext.AddTradeoffObjective("Structure");

            //if(plan.TradeoffExplorationContext.CanCreatePlanCollection)
            //{
            //    plan.TradeoffExplorationContext.CreatePlanCollection();

            //}

            //if(plan.TradeoffExplorationContext.HasPlanCollection)
            //{
            //    // possibly set certain values to explore different trade-offs
            //    // can only use these to explore situations for dose objectives that were specifically added as Trade Off Objectives
            //    // plan.TradeoffExplorationContext.SetObjectiveCost();
            //    // plan.TradeoffExplorationContext.SetObjectiveUpperRestrictor();

            //    // Evaluate trade offs
            //    // double oo = plan.TradeoffExplorationContext.GetObjectiveCost();
            //   // Dose tdose = plan.TradeoffExplorationContext.CurrentDose;
            //   DVHData da = plan.TradeoffExplorationContext.GetStructureDvh();

            //}



            //MessageBox.Show("internalcollisioncheck status: " + internalcollisioncheck.Status.ToString());

            //internalcollisioncheck.Wait();
            
            

            return;
        }









    }
}
