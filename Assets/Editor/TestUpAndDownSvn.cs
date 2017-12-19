using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class TestUpAndDownSvn
{
    private static string willUpFileName = Application.dataPath + "/Prefabs";
    private static string willDownFileName = "/Users/hyz/Documents/WebServer/SvnABDownload";
    private static string svnShellPath = Application.dataPath + "/Editor/SvnUpAndDown.sh";
    [MenuItem("Svn/UpAndDownSvn")]
    public static void LogLastBuildInfo()
    {
        Debug.LogError("Application.dataPath:" + Application.dataPath);
        Debug.LogError("willUpFileName:" + willUpFileName);
        var exportCommand = string.Format("{0} {1} {2}", svnShellPath,
            willUpFileName, willDownFileName);


        string output;
        TestUpAndDownSvn.ExecuteBashScript(exportCommand, out output);
        Debug.Log("=========================Upload Svn Log:" + output);
    }

    public static void ExecuteBashScript(string command, out string output)
    {
        Debug.LogError("command:"+command);

        var process = new Process
        {
            StartInfo =
            {
                FileName = "/bin/bash",
                Arguments = command,
                UseShellExecute = false,
                RedirectStandardOutput = true
            }
        };

        process.Start();

        output = process.StandardOutput.ReadToEnd();
        //Debug.Log(output);

        process.WaitForExit();
    }
}
