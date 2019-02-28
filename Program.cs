using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpssLib.SpssDataset;
using SpssLib.DataReader;
using System.IO;

namespace wacok_mom
{
    class Program
    {
        static void Main(string[] args)
        {
            int SurveyID = 600636;
            //string SurveyPeriod = "2014-09-30";//survey period
            string AttendedOn = "2018-12-31";
            //string year = getYear(SurveyPeriod); 
            string country = "Indonesia";//survey country
            DB_insertion_wacok_mom iobj = new DB_insertion_wacok_mom();
            string questions = "id,weight,S10,S9,S4,S11,S16,S17,C8,S18_1,S18_2,S18_3,S18_4,S18_5,S18_6,S18_7,S18_8,S19_1,S19_2,S19_3,S19_4,S19_5,S19_6,S19_7,S19_8,C1,C2_1,C2_2,C2_3,C2_4,C2_5,C2_6,C2_7,C2_8,C2_9,C2_10,C2_11,C2_12,C2_13,C2_14,C2_15,C2_16,C2_17,C2_18,C2_19,C2_20,C7,C9_1,C9_2,C9_3,C9_4,C9_5,C9_6,C9_7,C9_8,C9_9,C9_10,C9_11,C9_12,C9_13,C9_14,C9_15,C9_16,C9_17,C9_18,C9_19,C9_20,C14a,C15a,C3,C6,C11_1,C11_2,C11_3,C11_4,C11_5,C11_6,C11_7,C11_8,C11_9,C11_10,C11_11,C11_12,C11_13,C11_14,C11_15,C11_16,C11_17,C11_18,C11_19,C11_20,C10_1,C10_2,C10_3,C10_4,C10_5,C10_6,C10_7,C10_8,C10_9,C10_10,C10_11,C10_12,C10_13,C10_14,C10_15,C10_16,C10_17,C10_18,C10_19,C10_20,C12_1,C12_2,C12_3,C12_4,C12_5,C12_6,C12_7,C12_8,C12_9,C12_10,C12_11,C12_12,C12_13,C12_14,C12_15,C12_16,C12_17,C12_18,C12_19,C12_20,C13_1,C13_2,C13_3,C13_4,C13_5,C13_6,C13_7,C13_8,C13_9,C13_10,C13_11,C13_12,C13_13,C13_14,C13_15,C13_16,C13_17,C13_18,C13_19,C13_20,C31a1,C31a2,C31a3,C31a4,C31a5,C31a6,C31a7,C31a8,C31a9,C31b1,C31b2,C31b3,C31b4,C31b5,C31b6,C31b7,WA1_Net1,WA1_Net2,WA1_Net3,WA1_Net4,WA1_Net5,WA2_Net1,WA2_Net2,WA2_Net3,WA2_Net4,WA2_Net5,WA7_Net1,WA7_Net2,WA7_Net3,WA7_Net4,WA7_Net5,WA11_Net1,WA11_Net2,WA11_Net3,WA11_Net4,WA11_Net5,WA16_Net1,WA16_Net2,WA16_Net3,WA16_Net4,WA16_Net5,WA3_Net1,WA3_Net2,WA3_Net3,WA3_Net4,WA3_Net5,WA13_Net1,WA13_Net2,WA13_Net3,WA13_Net4,WA13_Net5,WA12_Net1,WA12_Net2,WA12_Net3,WA12_Net4,WA12_Net5,WA14_Net1,WA14_Net2,WA14_Net3,WA14_Net4,WA14_Net5,WA15_Net1,WA15_Net2,WA15_Net3,WA15_Net4,WA15_Net5,C4,C5_13,C5_14,C5_15,C5_16,C5_17,C5_18";// dashboard variable value                 
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"D:\spssparsing\wacokMom\Moms_Dec2018_SPSS.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {
                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                                //iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SurveyID, country, BASE_VARIABLE_NAME, AttendedOn);
                            }
                        }

                    }
                }
                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string u_id = null;
                    string variable_name;
                    decimal Weight = 0;
                    string Country = "-- Not Available --";
                    string Education = "-- Not Available --";
                    string Region = "-- Not Available --";
                    string Gender = "-- Not Available --";
                    string MaritalStatus = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string SES = "-- Not Available --";
                    string Occupation = "-- Not Available --";
                    string C8 = "-- Not Available --";
                    string Cat_ConsP1m_RTD_Milk = "-- Not Available --";
                    string Cat_ConsP1m_RTD_Coffee = "-- Not Available --";
                    string Cat_ConsP1m_RTD_Tea = "-- Not Available --";
                    string Cat_ConsP1m_Biscuits = "-- Not Available --";
                    string Cat_ConsP1m_Choc_Chee_Waf_or_Rolls = "-- Not Available --";
                    string Cat_ConsP1m_Chocolates = "-- Not Available --";
                    string Cat_ConsP1m_Carry_school_snack_from_home = "-- Not Available --";
                    string Cat_ConsP1m_Ins_Noodles = "-- Not Available --";
                    string Cat_ConsP1w_RTD_Milk = "-- Not Available --";
                    string Cat_ConsP1w_RTD_Coffee = "-- Not Available --";
                    string Cat_ConsP1w_RTD_Tea = "-- Not Available --";
                    string Cat_ConsP1w_Biscuits = "-- Not Available --";
                    string Cat_ConsP1w_Choc_Chee_Waf_or_Rolls = "-- Not Available --";
                    string Cat_ConsP1w_Chocolates = "-- Not Available --";
                    string Cat_ConsP1w_Carry_school_snack_from_home = "-- Not Available --";
                    string Cat_ConsP1w_Ins_Noodles = "-- Not Available --";
                    string BrTom = "-- Not Available --";
                    string BrSpont_Astor = "-- Not Available --";
                    string BrSpont_Fullo = "-- Not Available --";
                    string BrSpont_Gery_Chocolatos = "-- Not Available --";
                    string BrSpont_Gery_Chocolatos_Dark = "-- Not Available --";
                    string BrSpont_Gery_Saluut = "-- Not Available --";
                    string BrSpont_Nabati_Hansel = "-- Not Available --";
                    string BrSpont_Nissin_Wafer = "-- Not Available --";
                    string BrSpont_Richoco = "-- Not Available --";
                    string BrSpont_Richoco_Rolls = "-- Not Available --";
                    string BrSpont_Roma_Wafer = "-- Not Available --";
                    string BrSpont_Superstar = "-- Not Available --";
                    string BrSpont_Tango_Chocolate_Wafer = "-- Not Available --";
                    string BrSpont_Nissin_wafer_keju = "-- Not Available --";
                    string BrSpont_Oops_Wafer_Keju = "-- Not Available --";
                    string BrSpont_Richeese_Nabati_Keju = "-- Not Available --";
                    string BrSpont_Richeese_Rolls = "-- Not Available --";
                    string BrSpont_Tango_Long_Cheese = "-- Not Available --";
                    string BrSpont_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";
                    string BrSpont_Richoco_Nabati_White = "-- Not Available --";
                    string BrSpont_Richoco_Pink_Lava = "-- Not Available --";
                    string AdTom = "-- Not Available --";
                    string AdSpont_Astor = "-- Not Available --";
                    string AdSpont_Fullo = "-- Not Available --";
                    string AdSpont_Gery_Chocolatos = "-- Not Available --";
                    string AdSpont_Gery_Chocolatos_Dark = "-- Not Available --";
                    string AdSpont_Gery_Saluut = "-- Not Available --";
                    string AdSpont_Nabati_Hansel = "-- Not Available --";
                    string AdSpont_Nissin_Wafer = "-- Not Available --";
                    string AdSpont_Richoco = "-- Not Available --";
                    string AdSpont_Richoco_Rolls = "-- Not Available --";
                    string AdSpont_Roma_Wafer = "-- Not Available --";
                    string AdSpont_Superstar = "-- Not Available --";
                    string AdSpont_Tango_Chocolate_Wafer = "-- Not Available --";
                    string AdSpont_Nissin_wafer_keju = "-- Not Available --";
                    string AdSpont_Oops_Wafer_Keju = "-- Not Available --";
                    string AdSpont_Richeese_Nabati_Keju = "-- Not Available --";
                    string AdSpont_Richeese_Rolls = "-- Not Available --";
                    string AdSpont_Tango_Long_Cheese = "-- Not Available --";
                    string AdSpont_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";
                    string AdSpont_Richoco_Nabati_White = "-- Not Available --";
                    string AdSpont_Richoco_Pink_Lava = "-- Not Available --";
                    string Bumo = "-- Not Available --";
                    string BUMO_Cheese_wafer = "-- Not Available --";
                    string Favourite_Brand = "-- Not Available --";
                    string Favourite_Cheese_wafer = "-- Not Available --";
                    string ConL1M_Astor = "-- Not Available --";
                    string ConL1M_Fullo = "-- Not Available --";
                    string ConL1M_Gery_Chocolatos = "-- Not Available --";
                    string ConL1M_Gery_Chocolatos_Dark = "-- Not Available --";
                    string ConL1M_Gery_Saluut = "-- Not Available --";
                    string ConL1M_Nabati_Hansel = "-- Not Available --";
                    string ConL1M_Nissin_Wafer = "-- Not Available --";
                    string ConL1M_Richoco = "-- Not Available --";
                    string ConL1M_Richoco_Rolls = "-- Not Available --";
                    string ConL1M_Roma_Wafer = "-- Not Available --";
                    string ConL1M_Superstar = "-- Not Available --";
                    string ConL1M_Tango_Chocolate_Wafer = "-- Not Available --";
                    string ConL1M_Nissin_wafer_keju = "-- Not Available --";
                    string ConL1M_Oops_Wafer_Keju = "-- Not Available --";
                    string ConL1M_Richeese_Nabati_Keju = "-- Not Available --";
                    string ConL1M_Richeese_Rolls = "-- Not Available --";
                    string ConL1M_Tango_Long_Cheese = "-- Not Available --";
                    string ConL1M_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";
                    string ConL1M_Richoco_Nabati_White = "-- Not Available --";
                    string ConL1M_Richoco_Pink_Lava = "-- Not Available --";
                    string ConL3M_Astor = "-- Not Available --";
                    string ConL3M_Fullo = "-- Not Available --";
                    string ConL3M_Gery_Chocolatos = "-- Not Available --";
                    string ConL3M_Gery_Chocolatos_Dark = "-- Not Available --";
                    string ConL3M_Gery_Saluut = "-- Not Available --";
                    string ConL3M_Nabati_Hansel = "-- Not Available --";
                    string ConL3M_Nissin_Wafer = "-- Not Available --";
                    string ConL3M_Richoco = "-- Not Available --";
                    string ConL3M_Richoco_Rolls = "-- Not Available --";
                    string ConL3M_Roma_Wafer = "-- Not Available --";
                    string ConL3M_Superstar = "-- Not Available --";
                    string ConL3M_Tango_Chocolate_Wafer = "-- Not Available --";
                    string ConL3M_Nissin_wafer_keju = "-- Not Available --";
                    string ConL3M_Oops_Wafer_Keju = "-- Not Available --";
                    string ConL3M_Richeese_Nabati_Keju = "-- Not Available --";
                    string ConL3M_Richeese_Rolls = "-- Not Available --";
                    string ConL3M_Tango_Long_Cheese = "-- Not Available --";
                    string ConL3M_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";
                    string ConL3M_Richoco_Nabati_White = "-- Not Available --";
                    string ConL3M_Richoco_Pink_Lava = "-- Not Available --";
                    string ConL1W_Astor = "-- Not Available --";
                    string ConL1W_Fullo = "-- Not Available --";
                    string ConL1W_Gery_Chocolatos = "-- Not Available --";
                    string ConL1W_Gery_Chocolatos_Dark = "-- Not Available --";
                    string ConL1W_Gery_Saluut = "-- Not Available --";
                    string ConL1W_Nabati_Hansel = "-- Not Available --";
                    string ConL1W_Nissin_Wafer = "-- Not Available --";
                    string ConL1W_Richoco = "-- Not Available --";
                    string ConL1W_Richoco_Rolls = "-- Not Available --";
                    string ConL1W_Roma_Wafer = "-- Not Available --";
                    string ConL1W_Superstar = "-- Not Available --";
                    string ConL1W_Tango_Chocolate_Wafer = "-- Not Available --";
                    string ConL1W_Nissin_wafer_keju = "-- Not Available --";
                    string ConL1W_Oops_Wafer_Keju = "-- Not Available --";
                    string ConL1W_Richeese_Nabati_Keju = "-- Not Available --";
                    string ConL1W_Richeese_Rolls = "-- Not Available --";
                    string ConL1W_Tango_Long_Cheese = "-- Not Available --";
                    string ConL1W_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";
                    string ConL1W_Richoco_Nabati_White = "-- Not Available --";
                    string ConL1W_Richoco_Pink_Lava = "-- Not Available --";
                    string ConYestOrToday_Astor = "-- Not Available --";
                    string ConYestOrToday_Fullo = "-- Not Available --";
                    string ConYestOrToday_Gery_Chocolatos = "-- Not Available --";
                    string ConYestOrToday_Gery_Chocolatos_Dark = "-- Not Available --";
                    string ConYestOrToday_Gery_Saluut = "-- Not Available --";
                    string ConYestOrToday_Nabati_Hansel = "-- Not Available --";
                    string ConYestOrToday_Nissin_Wafer = "-- Not Available --";
                    string ConYestOrToday_Richoco = "-- Not Available --";
                    string ConYestOrToday_Richoco_Rolls = "-- Not Available --";
                    string ConYestOrToday_Roma_Wafer = "-- Not Available --";
                    string ConYestOrToday_Superstar = "-- Not Available --";
                    string ConYestOrToday_Tango_Chocolate_Wafer = "-- Not Available --";
                    string ConYestOrToday_Nissin_wafer_keju = "-- Not Available --";
                    string ConYestOrToday_Oops_Wafer_Keju = "-- Not Available --";
                    string ConYestOrToday_Richeese_Nabati_Keju = "-- Not Available --";
                    string ConYestOrToday_Richeese_Rolls = "-- Not Available --";
                    string ConYestOrToday_Tango_Long_Cheese = "-- Not Available --";
                    string ConYestOrToday_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";
                    string ConYestOrToday_Richoco_Nabati_White = "-- Not Available --";
                    string ConYestOrToday_Richoco_Pink_Lava = "-- Not Available --";
                    string C31a1 = "-- Not Available --";
                    string C31a2 = "-- Not Available --";
                    string C31a3 = "-- Not Available --";
                    string C31a4 = "-- Not Available --";
                    string C31a5 = "-- Not Available --";
                    string C31a6 = "-- Not Available --";
                    string C31a7 = "-- Not Available --";
                    string C31a8 = "-- Not Available --";
                    string C31a9 = "-- Not Available --";
                    string C31b1 = "-- Not Available --";
                    string C31b2 = "-- Not Available --";
                    string C31b3 = "-- Not Available --";
                    string C31b4 = "-- Not Available --";
                    string C31b5 = "-- Not Available --";
                    string C31b6 = "-- Not Available --";
                    string C31b7 = "-- Not Available --";
                    string BrTOm_Nett_Gery = "-- Not Available --";
                    string BrTOm_Nett_Richoco = "-- Not Available --";
                    string BrTOm_Nett_Richeese = "-- Not Available --";
                    string BrTOm_Nett_Chocolate_Wafer = "-- Not Available --";
                    string BrTOm_Nett_Cheese_Wafer = "-- Not Available --";
                    string BrSpont_Nett_Gery = "-- Not Available --";
                    string BrSpont_Nett_Richoco = "-- Not Available --";
                    string BrSpont_Nett_Richeese = "-- Not Available --";
                    string BrSpont_Nett_Chocolate_Wafer = "-- Not Available --";
                    string BrSpont_Nett_Cheese_Wafer = "-- Not Available --";
                    string NETT_TOM_Ad_Gery = "-- Not Available --";
                    string NETT_TOM_Ad_Richoco = "-- Not Available --";
                    string NETT_TOM_Ad_Richeese = "-- Not Available --";
                    string NETT_TOM_Ad_Chocolate_Wafer = "-- Not Available --";
                    string NETT_TOM_Ad_Cheese_Wafer = "-- Not Available --";
                    string NETT_Spont_Ad_Gery = "-- Not Available --";
                    string NETT_Spont_Ad_Richoco = "-- Not Available --";
                    string NETT_Spont_Ad_Richeese = "-- Not Available --";
                    string NETT_Spont_Ad_Chocolate_Wafer = "-- Not Available --";
                    string NETT_Spont_Ad_Cheese_Wafer = "-- Not Available --";
                    string NETT_BUMO_Gery = "-- Not Available --";
                    string NETT_BUMO_Richoco = "-- Not Available --";
                    string NETT_BUMO_Richeese = "-- Not Available --";
                    string NETT_BUMO_Chocolate_Wafer = "-- Not Available --";
                    string NETT_BUMO_Cheese_Wafer = "-- Not Available --";
                    string NETT_Fav_Gery = "-- Not Available --";
                    string NETT_Fav_Richoco = "-- Not Available --";
                    string NETT_Fav_Richeese = "-- Not Available --";
                    string NETT_Fav_Chocolate_Wafer = "-- Not Available --";
                    string NETT_Fav_Cheese_Wafer = "-- Not Available --";
                    string NETT_P1M_Con_Gery = "-- Not Available --";
                    string NETT_P1M_Con_Richoco = "-- Not Available --";
                    string NETT_P1M_Con_Richeese = "-- Not Available --";
                    string NETT_P1M_Con_Chocolate_Wafer = "-- Not Available --";
                    string NETT_P1M_Con_Cheese_Wafer = "-- Not Available --";
                    string NETT_P3M_Con_Gery = "-- Not Available --";
                    string NETT_P3M_Con_Richoco = "-- Not Available --";
                    string NETT_P3M_Con_Richeese = "-- Not Available --";
                    string NETT_P3M_Con_Chocolate_Wafer = "-- Not Available --";
                    string NETT_P3M_Con_Cheese_Wafer = "-- Not Available --";
                    string NETT_P1W_Con_Gery = "-- Not Available --";
                    string NETT_P1W_Con_Richoco = "-- Not Available --";
                    string NETT_P1W_Con_Richeese = "-- Not Available --";
                    string NETT_P1W_Con_Chocolate_Wafer = "-- Not Available --";
                    string NETT_P1W_Con_Cheese_Wafer = "-- Not Available --";
                    string NETT_ConYestOrToday_Gery = "-- Not Available --";
                    string NETT_ConYestOrToday_Richoco = "-- Not Available --";
                    string NETT_ConYestOrToday_Richeese = "-- Not Available --";
                    string NETT_ConYestOrToday_Chocolate_Wafer = "-- Not Available --";
                    string NETT_ConYestOrToday_Cheese_Wafer = "-- Not Available --";
                    string BrTom_Cheese_Waf = "-- Not Available --";
                    string BrSpont_CW_Nissin_wafer_keju = "-- Not Available --";
                    string BrSpont_CW_Oops_Wafer_Keju = "-- Not Available --";
                    string BrSpont_CW_Richeese_Nabati_Keju = "-- Not Available --";
                    string BrSpont_CW_Richeese_Rolls = "-- Not Available --";
                    string BrSpont_CW_Tango_Long_Cheese = "-- Not Available --";
                    string BrSpont_CW_Zuperrr_Keju_Wafer_Keju = "-- Not Available --";

                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;

                                switch (variable_name)
                                {
                                    case "id":
                                        {
                                            u_id = Convert.ToString(record.GetValue(variable));
                                            userID = find_UserId(SurveyID, AttendedOn, u_id);
                                            break;
                                        }
                                    case "weight":
                                        {
                                            Weight = Convert.ToDecimal(record.GetValue(variable));
                                            break;
                                        }
                                    case "S10": { SES = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S9": { Region = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S4": { AgeGroup = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S11": { MaritalStatus = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S16": { Occupation = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S17": { Education = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C8": { C8 = Convert.ToString(record.GetValue(variable)); break; }

                                    case "S18_1": { Cat_ConsP1m_RTD_Milk = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_2": { Cat_ConsP1m_RTD_Coffee = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_3": { Cat_ConsP1m_RTD_Tea = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_4": { Cat_ConsP1m_Biscuits = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_5": { Cat_ConsP1m_Choc_Chee_Waf_or_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_6": { Cat_ConsP1m_Chocolates = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_7": { Cat_ConsP1m_Carry_school_snack_from_home = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S18_8": { Cat_ConsP1m_Ins_Noodles = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_1": { Cat_ConsP1w_RTD_Milk = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_2": { Cat_ConsP1w_RTD_Coffee = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_3": { Cat_ConsP1w_RTD_Tea = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_4": { Cat_ConsP1w_Biscuits = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_5": { Cat_ConsP1w_Choc_Chee_Waf_or_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_6": { Cat_ConsP1w_Chocolates = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_7": { Cat_ConsP1w_Carry_school_snack_from_home = Convert.ToString(record.GetValue(variable)); break; }
                                    case "S19_8": { Cat_ConsP1w_Ins_Noodles = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C1": { BrTom = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_1": { BrSpont_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_2": { BrSpont_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_3": { BrSpont_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_4": { BrSpont_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_5": { BrSpont_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_6": { BrSpont_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_7": { BrSpont_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_8": { BrSpont_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_9": { BrSpont_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_10": { BrSpont_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_11": { BrSpont_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_12": { BrSpont_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_13": { BrSpont_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_14": { BrSpont_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_15": { BrSpont_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_16": { BrSpont_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_17": { BrSpont_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_18": { BrSpont_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_19": { BrSpont_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C2_20": { BrSpont_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C7": { AdTom = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_1": { AdSpont_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_2": { AdSpont_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_3": { AdSpont_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_4": { AdSpont_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_5": { AdSpont_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_6": { AdSpont_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_7": { AdSpont_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_8": { AdSpont_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_9": { AdSpont_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_10": { AdSpont_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_11": { AdSpont_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_12": { AdSpont_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_13": { AdSpont_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_14": { AdSpont_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_15": { AdSpont_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_16": { AdSpont_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_17": { AdSpont_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_18": { AdSpont_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_19": { AdSpont_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C9_20": { AdSpont_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C14a": { Bumo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C15a": { BUMO_Cheese_wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C3": { Favourite_Brand = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C6": { Favourite_Cheese_wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_1": { ConL1M_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_2": { ConL1M_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_3": { ConL1M_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_4": { ConL1M_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_5": { ConL1M_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_6": { ConL1M_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_7": { ConL1M_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_8": { ConL1M_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_9": { ConL1M_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_10": { ConL1M_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_11": { ConL1M_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_12": { ConL1M_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_13": { ConL1M_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_14": { ConL1M_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_15": { ConL1M_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_16": { ConL1M_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_17": { ConL1M_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_18": { ConL1M_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_19": { ConL1M_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C11_20": { ConL1M_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_1": { ConL3M_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_2": { ConL3M_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_3": { ConL3M_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_4": { ConL3M_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_5": { ConL3M_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_6": { ConL3M_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_7": { ConL3M_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_8": { ConL3M_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_9": { ConL3M_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_10": { ConL3M_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_11": { ConL3M_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_12": { ConL3M_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_13": { ConL3M_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_14": { ConL3M_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_15": { ConL3M_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_16": { ConL3M_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_17": { ConL3M_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_18": { ConL3M_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_19": { ConL3M_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C10_20": { ConL3M_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_1": { ConL1W_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_2": { ConL1W_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_3": { ConL1W_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_4": { ConL1W_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_5": { ConL1W_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_6": { ConL1W_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_7": { ConL1W_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_8": { ConL1W_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_9": { ConL1W_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_10": { ConL1W_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_11": { ConL1W_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_12": { ConL1W_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_13": { ConL1W_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_14": { ConL1W_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_15": { ConL1W_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_16": { ConL1W_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_17": { ConL1W_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_18": { ConL1W_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_19": { ConL1W_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C12_20": { ConL1W_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_1": { ConYestOrToday_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_2": { ConYestOrToday_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_3": { ConYestOrToday_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_4": { ConYestOrToday_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_5": { ConYestOrToday_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_6": { ConYestOrToday_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_7": { ConYestOrToday_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_8": { ConYestOrToday_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_9": { ConYestOrToday_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_10": { ConYestOrToday_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_11": { ConYestOrToday_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_12": { ConYestOrToday_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_13": { ConYestOrToday_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_14": { ConYestOrToday_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_15": { ConYestOrToday_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_16": { ConYestOrToday_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_17": { ConYestOrToday_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_18": { ConYestOrToday_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_19": { ConYestOrToday_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C13_20": { ConYestOrToday_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a1": { C31a1 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a2": { C31a2 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a3": { C31a3 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a4": { C31a4 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a5": { C31a5 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a6": { C31a6 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a7": { C31a7 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a8": { C31a8 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31a9": { C31a9 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b1": { C31b1 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b2": { C31b2 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b3": { C31b3 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b4": { C31b4 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b5": { C31b5 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b6": { C31b6 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C31b7": { C31b7 = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA1_Net1": { BrTOm_Nett_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA1_Net2": { BrTOm_Nett_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA1_Net3": { BrTOm_Nett_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA1_Net4": { BrTOm_Nett_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA1_Net5": { BrTOm_Nett_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA2_Net1": { BrSpont_Nett_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA2_Net2": { BrSpont_Nett_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA2_Net3": { BrSpont_Nett_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA2_Net4": { BrSpont_Nett_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA2_Net5": { BrSpont_Nett_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA7_Net1": { NETT_TOM_Ad_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA7_Net2": { NETT_TOM_Ad_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA7_Net3": { NETT_TOM_Ad_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA7_Net4": { NETT_TOM_Ad_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA7_Net5": { NETT_TOM_Ad_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA11_Net1": { NETT_Spont_Ad_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA11_Net2": { NETT_Spont_Ad_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA11_Net3": { NETT_Spont_Ad_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA11_Net4": { NETT_Spont_Ad_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA11_Net5": { NETT_Spont_Ad_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA16_Net1": { NETT_BUMO_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA16_Net2": { NETT_BUMO_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA16_Net3": { NETT_BUMO_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA16_Net4": { NETT_BUMO_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA16_Net5": { NETT_BUMO_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA3_Net1": { NETT_Fav_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA3_Net2": { NETT_Fav_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA3_Net3": { NETT_Fav_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA3_Net4": { NETT_Fav_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA3_Net5": { NETT_Fav_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA13_Net1": { NETT_P1M_Con_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA13_Net2": { NETT_P1M_Con_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA13_Net3": { NETT_P1M_Con_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA13_Net4": { NETT_P1M_Con_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA13_Net5": { NETT_P1M_Con_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA12_Net1": { NETT_P3M_Con_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA12_Net2": { NETT_P3M_Con_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA12_Net3": { NETT_P3M_Con_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA12_Net4": { NETT_P3M_Con_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA12_Net5": { NETT_P3M_Con_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA14_Net1": { NETT_P1W_Con_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA14_Net2": { NETT_P1W_Con_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA14_Net3": { NETT_P1W_Con_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA14_Net4": { NETT_P1W_Con_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA14_Net5": { NETT_P1W_Con_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA15_Net1": { NETT_ConYestOrToday_Gery = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA15_Net2": { NETT_ConYestOrToday_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA15_Net3": { NETT_ConYestOrToday_Richeese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA15_Net4": { NETT_ConYestOrToday_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "WA15_Net5": { NETT_ConYestOrToday_Cheese_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C4": { BrTom_Cheese_Waf = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C5_13": { BrSpont_CW_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C5_14": { BrSpont_CW_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C5_15": { BrSpont_CW_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C5_16": { BrSpont_CW_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C5_17": { BrSpont_CW_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                    case "C5_18": { BrSpont_CW_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                }

                            }
                        }
                    }

                    if (userID != null && Weight != 0 && AgeGroup.Equals("2") || AgeGroup.Equals("3"))
                    {
                        iobj.insert_Dashboard_values(userID, SurveyID, AttendedOn, Weight, country, Region, MaritalStatus, Occupation, Education, AgeGroup, SES, C8, Cat_ConsP1m_RTD_Milk, Cat_ConsP1m_RTD_Coffee, Cat_ConsP1m_RTD_Tea, Cat_ConsP1m_Biscuits, Cat_ConsP1m_Choc_Chee_Waf_or_Rolls, Cat_ConsP1m_Chocolates, Cat_ConsP1m_Carry_school_snack_from_home, Cat_ConsP1m_Ins_Noodles, Cat_ConsP1w_RTD_Milk, Cat_ConsP1w_RTD_Coffee, Cat_ConsP1w_RTD_Tea, Cat_ConsP1w_Biscuits, Cat_ConsP1w_Choc_Chee_Waf_or_Rolls, Cat_ConsP1w_Chocolates, Cat_ConsP1w_Carry_school_snack_from_home, Cat_ConsP1w_Ins_Noodles, BrTom, BrSpont_Astor, BrSpont_Fullo, BrSpont_Gery_Chocolatos, BrSpont_Gery_Chocolatos_Dark, BrSpont_Gery_Saluut, BrSpont_Nabati_Hansel, BrSpont_Nissin_Wafer, BrSpont_Richoco, BrSpont_Richoco_Rolls, BrSpont_Roma_Wafer, BrSpont_Superstar, BrSpont_Tango_Chocolate_Wafer, BrSpont_Nissin_wafer_keju, BrSpont_Oops_Wafer_Keju, BrSpont_Richeese_Nabati_Keju, BrSpont_Richeese_Rolls, BrSpont_Tango_Long_Cheese, BrSpont_Zuperrr_Keju_Wafer_Keju, BrSpont_Richoco_Nabati_White, BrSpont_Richoco_Pink_Lava, AdTom, AdSpont_Astor, AdSpont_Fullo, AdSpont_Gery_Chocolatos, AdSpont_Gery_Chocolatos_Dark, AdSpont_Gery_Saluut, AdSpont_Nabati_Hansel, AdSpont_Nissin_Wafer, AdSpont_Richoco, AdSpont_Richoco_Rolls, AdSpont_Roma_Wafer, AdSpont_Superstar, AdSpont_Tango_Chocolate_Wafer, AdSpont_Nissin_wafer_keju, AdSpont_Oops_Wafer_Keju, AdSpont_Richeese_Nabati_Keju, AdSpont_Richeese_Rolls, AdSpont_Tango_Long_Cheese, AdSpont_Zuperrr_Keju_Wafer_Keju, AdSpont_Richoco_Nabati_White, AdSpont_Richoco_Pink_Lava, Bumo, BUMO_Cheese_wafer, Favourite_Brand, Favourite_Cheese_wafer, ConL1M_Astor, ConL1M_Fullo, ConL1M_Gery_Chocolatos, ConL1M_Gery_Chocolatos_Dark, ConL1M_Gery_Saluut, ConL1M_Nabati_Hansel, ConL1M_Nissin_Wafer, ConL1M_Richoco, ConL1M_Richoco_Rolls, ConL1M_Roma_Wafer, ConL1M_Superstar, ConL1M_Tango_Chocolate_Wafer, ConL1M_Nissin_wafer_keju, ConL1M_Oops_Wafer_Keju, ConL1M_Richeese_Nabati_Keju, ConL1M_Richeese_Rolls, ConL1M_Tango_Long_Cheese, ConL1M_Zuperrr_Keju_Wafer_Keju, ConL1M_Richoco_Nabati_White, ConL1M_Richoco_Pink_Lava, ConL3M_Astor, ConL3M_Fullo, ConL3M_Gery_Chocolatos, ConL3M_Gery_Chocolatos_Dark, ConL3M_Gery_Saluut, ConL3M_Nabati_Hansel, ConL3M_Nissin_Wafer, ConL3M_Richoco, ConL3M_Richoco_Rolls, ConL3M_Roma_Wafer, ConL3M_Superstar, ConL3M_Tango_Chocolate_Wafer, ConL3M_Nissin_wafer_keju, ConL3M_Oops_Wafer_Keju, ConL3M_Richeese_Nabati_Keju, ConL3M_Richeese_Rolls, ConL3M_Tango_Long_Cheese, ConL3M_Zuperrr_Keju_Wafer_Keju, ConL3M_Richoco_Nabati_White, ConL3M_Richoco_Pink_Lava, ConL1W_Astor, ConL1W_Fullo, ConL1W_Gery_Chocolatos, ConL1W_Gery_Chocolatos_Dark, ConL1W_Gery_Saluut, ConL1W_Nabati_Hansel, ConL1W_Nissin_Wafer, ConL1W_Richoco, ConL1W_Richoco_Rolls, ConL1W_Roma_Wafer, ConL1W_Superstar, ConL1W_Tango_Chocolate_Wafer, ConL1W_Nissin_wafer_keju, ConL1W_Oops_Wafer_Keju, ConL1W_Richeese_Nabati_Keju, ConL1W_Richeese_Rolls, ConL1W_Tango_Long_Cheese, ConL1W_Zuperrr_Keju_Wafer_Keju, ConL1W_Richoco_Nabati_White, ConL1W_Richoco_Pink_Lava, ConYestOrToday_Astor, ConYestOrToday_Fullo, ConYestOrToday_Gery_Chocolatos, ConYestOrToday_Gery_Chocolatos_Dark, ConYestOrToday_Gery_Saluut, ConYestOrToday_Nabati_Hansel, ConYestOrToday_Nissin_Wafer, ConYestOrToday_Richoco, ConYestOrToday_Richoco_Rolls, ConYestOrToday_Roma_Wafer, ConYestOrToday_Superstar, ConYestOrToday_Tango_Chocolate_Wafer, ConYestOrToday_Nissin_wafer_keju, ConYestOrToday_Oops_Wafer_Keju, ConYestOrToday_Richeese_Nabati_Keju, ConYestOrToday_Richeese_Rolls, ConYestOrToday_Tango_Long_Cheese, ConYestOrToday_Zuperrr_Keju_Wafer_Keju, ConYestOrToday_Richoco_Nabati_White, ConYestOrToday_Richoco_Pink_Lava, C31a1, C31a2, C31a3, C31a4, C31a5, C31a6, C31a7, C31a8, C31a9, C31b1, C31b2, C31b3, C31b4, C31b5, C31b6, C31b7, BrTOm_Nett_Gery, BrTOm_Nett_Richoco, BrTOm_Nett_Richeese, BrTOm_Nett_Chocolate_Wafer, BrTOm_Nett_Cheese_Wafer, BrSpont_Nett_Gery, BrSpont_Nett_Richoco, BrSpont_Nett_Richeese, BrSpont_Nett_Chocolate_Wafer, BrSpont_Nett_Cheese_Wafer, NETT_TOM_Ad_Gery, NETT_TOM_Ad_Richoco, NETT_TOM_Ad_Richeese, NETT_TOM_Ad_Chocolate_Wafer, NETT_TOM_Ad_Cheese_Wafer, NETT_Spont_Ad_Gery, NETT_Spont_Ad_Richoco, NETT_Spont_Ad_Richeese, NETT_Spont_Ad_Chocolate_Wafer, NETT_Spont_Ad_Cheese_Wafer, NETT_BUMO_Gery, NETT_BUMO_Richoco, NETT_BUMO_Richeese, NETT_BUMO_Chocolate_Wafer, NETT_BUMO_Cheese_Wafer, NETT_Fav_Gery, NETT_Fav_Richoco, NETT_Fav_Richeese, NETT_Fav_Chocolate_Wafer, NETT_Fav_Cheese_Wafer, NETT_P1M_Con_Gery, NETT_P1M_Con_Richoco, NETT_P1M_Con_Richeese, NETT_P1M_Con_Chocolate_Wafer, NETT_P1M_Con_Cheese_Wafer, NETT_P3M_Con_Gery, NETT_P3M_Con_Richoco, NETT_P3M_Con_Richeese, NETT_P3M_Con_Chocolate_Wafer, NETT_P3M_Con_Cheese_Wafer, NETT_P1W_Con_Gery, NETT_P1W_Con_Richoco, NETT_P1W_Con_Richeese, NETT_P1W_Con_Chocolate_Wafer, NETT_P1W_Con_Cheese_Wafer, NETT_ConYestOrToday_Gery, NETT_ConYestOrToday_Richoco, NETT_ConYestOrToday_Richeese, NETT_ConYestOrToday_Chocolate_Wafer, NETT_ConYestOrToday_Cheese_Wafer, BrTom_Cheese_Waf, BrSpont_CW_Nissin_wafer_keju, BrSpont_CW_Oops_Wafer_Keju, BrSpont_CW_Richeese_Nabati_Keju, BrSpont_CW_Richeese_Rolls, BrSpont_CW_Tango_Long_Cheese, BrSpont_CW_Zuperrr_Keju_Wafer_Keju);
                    }
                }
            }
        }
        private static string find_UserId(int SurveyID, string SurveyPeriod, string u_id)
        {
            string sum = "";
            string[] date = SurveyPeriod.Split('-');
            foreach (string d in date)
            {
                sum = sum + d;

            }
            return u_id + SurveyID + sum;
        }
    }


}
