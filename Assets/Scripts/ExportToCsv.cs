using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
public class ExportToCsv : MonoBehaviour
{
   



private static string csvFolderName = "CSV";
    private static string csvFileName = "Steinbrenner.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[1] {
       "Vrijednosti izracuna:"
    };
    
//main function
    public  void AppendToReport() {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath())) {
GameObject programManager = GameObject.Find("ProgramManager");
ProgramState programState = programManager.GetComponent<ProgramState>();

 SteinbrennerFormula initializeSteinbrennerCalculation = programManager.GetComponent<SteinbrennerFormula>();
 (List<double>depthList, List<double> valueList) SteinBrennerRezultat= initializeSteinbrennerCalculation.CalculateSteinbrenner(programState.sirinaB, programState.duzinaL);

            
                       sw.WriteLine("Z,i,Duzina temelja, Sirina temelja, Dubina mjerenja, Vrijeme");
                       sw.WriteLine( " , ,  "+programState.duzinaL+","+programState.sirinaB+","+programState.dubinaZ+ "," + GetTimeStamp());
                        sw.WriteLine("__________________");
          for(var i = 0; i < SteinBrennerRezultat.depthList.Count; i ++){
                
               sw.WriteLine(SteinBrennerRezultat.depthList[i]+","+SteinBrennerRezultat.valueList[i]);
               
              
             
            };
                                    sw.WriteLine("______________________________________________________");
                                    sw.WriteLine("");
                                    sw.WriteLine("");




            // finalString += reportSeparator + GetTimeStamp();
            // sw.WriteLine(finalString);
        }

        
         GameObject exportToCsvButton = GameObject.Find("ExportToCsv");
            exportToCsvButton.SetActive(false);
    }

    public static void CreateReport() {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath())) {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator ;
            sw.WriteLine(finalString);
                       
             sw.WriteLine("______________________________________________________");
            sw.WriteLine("");

        }
    }


    static void VerifyDirectory() {
        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }
    }

    static void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
        }
    }





    static string GetDirectoryPath() {
        return Application.dataPath + "/" + csvFolderName;
    }

    static string GetFilePath() {
        return GetDirectoryPath() + "/" + csvFileName;
    }

    static string GetTimeStamp() {
        DateTime startTimeFormate = System.DateTime.UtcNow; // This  is utc date time
TimeZoneInfo systemTimeZone = TimeZoneInfo.Local;
DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(startTimeFormate, systemTimeZone);

        return localDateTime.ToString();
    }



}
