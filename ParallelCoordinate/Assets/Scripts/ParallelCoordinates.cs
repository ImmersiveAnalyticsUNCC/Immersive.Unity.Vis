using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ParallelCoordinates : MonoBehaviour
{

    public static int hLines = 0;

    void Awake()
    {
        string dataAsJson = File.ReadAllText("Assets/Data/StatePercentages" + StateLayoutManager.year + ".json");
        AllStateReleasePercentages percents = JsonUtility.FromJson<AllStateReleasePercentages>(dataAsJson);

        /*
         * Axes:
         * Start: 200, 50 -> 150, -50
         * Carcinogen: 200, 50 -> 150, -150
         * Clean Air: 200, 50 -> 150, -300
         * Metal: 200, 50 -> 150, -450
         * Federal: 200, 50 -> 150, -600
        */


        GameObject lineObject = new GameObject("AL Line");
        lineObject.tag = "AL";
        LineRenderer line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        Vector3[] positions = new Vector3[5];
        positions[0] = new Vector3(200, 175, -50);
        positions[1] = new Vector3(200, (percents.AL.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AL.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AL.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AL.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("AK Line");
        lineObject.tag = "AK";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 170, -50);
        positions[1] = new Vector3(200, (percents.AK.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AK.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AK.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AK.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("AZ Line");
        lineObject.tag = "AZ";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 165, -50);
        positions[1] = new Vector3(200, (percents.AZ.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AZ.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AZ.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AZ.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("AR Line");
        lineObject.tag = "AR";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 160, -50);
        positions[1] = new Vector3(200, (percents.AR.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AR.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AR.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AR.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("CA Line");
        lineObject.tag = "CA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 155, -50);//x, 155, x; change the middle number by 5 each time
        positions[1] = new Vector3(200, (percents.CA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.CA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.CA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.CA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("CO Line");
        lineObject.tag = "CO";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 150, -50);
        positions[1] = new Vector3(200, (percents.CO.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.CO.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.CO.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.CO.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("CT Line");
        lineObject.tag = "CT";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 145, -50);
        positions[1] = new Vector3(200, (percents.CT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.CT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.CT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.CT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("DE Line");
        lineObject.tag = "DE";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 140, -50);
        positions[1] = new Vector3(200, (percents.DE.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.DE.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.DE.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.DE.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("FL Line");
        lineObject.tag = "FL";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 135, -50);
        positions[1] = new Vector3(200, (percents.FL.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.FL.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.FL.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.FL.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("GA Line");
        lineObject.tag = "GA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 130, -50);
        positions[1] = new Vector3(200, (percents.GA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.GA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.GA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.GA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("HI Line");
        lineObject.tag = "HI";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 125, -50);
        positions[1] = new Vector3(200, (percents.HI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.HI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.HI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.HI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("ID Line");
        lineObject.tag = "ID";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 120, -50);
        positions[1] = new Vector3(200, (percents.ID.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.ID.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.ID.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.ID.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("IL Line");
        lineObject.tag = "IL";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 115, -50);
        positions[1] = new Vector3(200, (percents.IL.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.IL.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.IL.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.IL.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("IN Line");
        lineObject.tag = "IN";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 110, -50);
        positions[1] = new Vector3(200, (percents.IN.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.IN.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.IN.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.IN.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("IA Line");
        lineObject.tag = "IA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 105, -50);
        positions[1] = new Vector3(200, (percents.IA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.IA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.IA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.IA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("KS Line");
        lineObject.tag = "KS";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 100, -50);
        positions[1] = new Vector3(200, (percents.KS.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.KS.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.KS.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.KS.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("KY Line");
        lineObject.tag = "KY";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 95, -50);
        positions[1] = new Vector3(200, (percents.KY.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.KY.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.KY.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.KY.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("LA Line");
        lineObject.tag = "LA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 90, -50);
        positions[1] = new Vector3(200, (percents.LA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.LA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.LA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.LA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("ME Line");
        lineObject.tag = "ME";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 85, -50);
        positions[1] = new Vector3(200, (percents.ME.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.ME.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.ME.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.ME.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MD Line");
        lineObject.tag = "MD";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 80, -50);
        positions[1] = new Vector3(200, (percents.MD.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MD.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MD.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MD.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MA Line");
        lineObject.tag = "MA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 75, -50);
        positions[1] = new Vector3(200, (percents.MA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MI Line");
        lineObject.tag = "MI";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 70, -50);
        positions[1] = new Vector3(200, (percents.MI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MN Line");
        lineObject.tag = "MN";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 65, -50);
        positions[1] = new Vector3(200, (percents.MN.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MN.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MN.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MN.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MS Line");
        lineObject.tag = "MS";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 60, -50);
        positions[1] = new Vector3(200, (percents.MS.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MS.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MS.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MS.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MO Line");
        lineObject.tag = "MO";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 55, -50);
        positions[1] = new Vector3(200, (percents.MO.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MO.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MO.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MO.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("MT Line");
        lineObject.tag = "MT";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 50, -50);
        positions[1] = new Vector3(200, (percents.MT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NE Line");
        lineObject.tag = "NE";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 45, -50);
        positions[1] = new Vector3(200, (percents.NE.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NE.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NE.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NE.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NV Line");
        lineObject.tag = "NV";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 40, -50);
        positions[1] = new Vector3(200, (percents.NV.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NV.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NV.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NV.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NH Line");
        lineObject.tag = "NH";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 35, -50);
        positions[1] = new Vector3(200, (percents.NH.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NH.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NH.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NH.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NJ Line");
        lineObject.tag = "NJ";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 30, -50);
        positions[1] = new Vector3(200, (percents.NJ.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NJ.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NJ.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NJ.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NM Line");
        lineObject.tag = "NM";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 25, -50);
        positions[1] = new Vector3(200, (percents.NM.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NM.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NM.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NM.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NY Line");
        lineObject.tag = "NY";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 20, -50);
        positions[1] = new Vector3(200, (percents.NY.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NY.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NY.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NY.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("NC Line");
        lineObject.tag = "NC";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 15, -50);
        positions[1] = new Vector3(200, (percents.NC.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NC.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NC.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NC.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("ND Line");
        lineObject.tag = "ND";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 10, -50);
        positions[1] = new Vector3(200, (percents.ND.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.ND.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.ND.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.ND.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("OH Line");
        lineObject.tag = "OH";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 5, -50);
        positions[1] = new Vector3(200, (percents.OH.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.OH.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.OH.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.OH.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("OK Line");
        lineObject.tag = "OK";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 0, -50);
        positions[1] = new Vector3(200, (percents.OK.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.OK.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.OK.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.OK.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("OR Line");
        lineObject.tag = "OR";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -5, -50);
        positions[1] = new Vector3(200, (percents.OR.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.OR.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.OR.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.OR.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("PA Line");
        lineObject.tag = "PA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -10, -50);
        positions[1] = new Vector3(200, (percents.PA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.PA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.PA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.PA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("RI Line");
        lineObject.tag = "RI";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -15, -50);
        positions[1] = new Vector3(200, (percents.RI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.RI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.RI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.RI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("SC Line");
        lineObject.tag = "SC";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -20, -50);
        positions[1] = new Vector3(200, (percents.SC.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.SC.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.SC.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.SC.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("SD Line");
        lineObject.tag = "SD";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -25, -50);
        positions[1] = new Vector3(200, (percents.SD.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.SD.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.SD.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.SD.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("TN Line");
        lineObject.tag = "TN";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -30, -50);
        positions[1] = new Vector3(200, (percents.TN.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.TN.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.TN.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.TN.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("TX Line");
        lineObject.tag = "TX";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -35, -50);
        positions[1] = new Vector3(200, (percents.TX.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.TX.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.TX.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.TX.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("UT Line");
        lineObject.tag = "UT";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -40, -50);
        positions[1] = new Vector3(200, (percents.UT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.UT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.UT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.UT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("VT Line");
        lineObject.tag = "VT";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -45, -50);
        positions[1] = new Vector3(200, (percents.VT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.VT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.VT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.VT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("VA Line");
        lineObject.tag = "VA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -50, -50);
        positions[1] = new Vector3(200, (percents.VA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.VA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.VA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.VA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("WA Line");
        lineObject.tag = "WA";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -55, -50);
        positions[1] = new Vector3(200, (percents.WA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("WV Line");
        lineObject.tag = "WV";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -60, -50);
        positions[1] = new Vector3(200, (percents.WV.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WV.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WV.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WV.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("WI Line");
        lineObject.tag = "WI";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -65, -50);
        positions[1] = new Vector3(200, (percents.WI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = new GameObject("WY Line");
        lineObject.tag = "WY";
        line = lineObject.AddComponent<LineRenderer>();
        line.positionCount = 5;
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.endColor = new Color(0, 255, 255, .5f);
        line.startColor = new Color(0, 255, 255, .5f);
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -70, -50);
        positions[1] = new Vector3(200, (percents.WY.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WY.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WY.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WY.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);
    }

    public static void Update()
    {
        string dataAsJson = File.ReadAllText("Assets/Data/StatePercentages" + StateLayoutManager.year + ".json");
        AllStateReleasePercentages percents = JsonUtility.FromJson<AllStateReleasePercentages>(dataAsJson);

        /*
         * Axes:
         * Start: 200, 50 -> 150, -50
         * Carcinogen: 200, 50 -> 150, -150
         * Clean Air: 200, 50 -> 150, -300
         * Metal: 200, 50 -> 150, -450
         * Federal: 200, 50 -> 150, -600
        */


        GameObject lineObject = GameObject.Find("AL Line");
        LineRenderer line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        Vector3[] positions = new Vector3[5];
        positions[0] = new Vector3(200, 175, -50);
        positions[1] = new Vector3(200, (percents.AL.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AL.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AL.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AL.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("AK Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 170, -50);
        positions[1] = new Vector3(200, (percents.AK.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AK.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AK.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AK.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("AZ Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 165, -50);
        positions[1] = new Vector3(200, (percents.AZ.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AZ.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AZ.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AZ.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("AR Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 160, -50);
        positions[1] = new Vector3(200, (percents.AR.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.AR.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.AR.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.AR.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("CA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 155, -50);//x, 155, x; change the middle number by 5 each time
        positions[1] = new Vector3(200, (percents.CA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.CA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.CA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.CA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("CO Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 150, -50);
        positions[1] = new Vector3(200, (percents.CO.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.CO.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.CO.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.CO.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("CT Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 145, -50);
        positions[1] = new Vector3(200, (percents.CT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.CT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.CT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.CT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("DE Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 140, -50);
        positions[1] = new Vector3(200, (percents.DE.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.DE.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.DE.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.DE.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("FL Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 135, -50);
        positions[1] = new Vector3(200, (percents.FL.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.FL.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.FL.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.FL.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("GA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 130, -50);
        positions[1] = new Vector3(200, (percents.GA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.GA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.GA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.GA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("HI Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 125, -50);
        positions[1] = new Vector3(200, (percents.HI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.HI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.HI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.HI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("ID Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 120, -50);
        positions[1] = new Vector3(200, (percents.ID.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.ID.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.ID.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.ID.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("IL Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 115, -50);
        positions[1] = new Vector3(200, (percents.IL.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.IL.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.IL.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.IL.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("IN Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 110, -50);
        positions[1] = new Vector3(200, (percents.IN.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.IN.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.IN.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.IN.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("IA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 105, -50);
        positions[1] = new Vector3(200, (percents.IA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.IA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.IA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.IA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("KS Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 100, -50);
        positions[1] = new Vector3(200, (percents.KS.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.KS.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.KS.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.KS.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("KY Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 95, -50);
        positions[1] = new Vector3(200, (percents.KY.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.KY.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.KY.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.KY.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("LA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 90, -50);
        positions[1] = new Vector3(200, (percents.LA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.LA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.LA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.LA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("ME Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 85, -50);
        positions[1] = new Vector3(200, (percents.ME.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.ME.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.ME.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.ME.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MD Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 80, -50);
        positions[1] = new Vector3(200, (percents.MD.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MD.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MD.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MD.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 75, -50);
        positions[1] = new Vector3(200, (percents.MA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MI Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 70, -50);
        positions[1] = new Vector3(200, (percents.MI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MN Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 65, -50);
        positions[1] = new Vector3(200, (percents.MN.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MN.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MN.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MN.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MS Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 60, -50);
        positions[1] = new Vector3(200, (percents.MS.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MS.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MS.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MS.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MO Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 55, -50);
        positions[1] = new Vector3(200, (percents.MO.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MO.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MO.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MO.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("MT Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 50, -50);
        positions[1] = new Vector3(200, (percents.MT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.MT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.MT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.MT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NE Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 45, -50);
        positions[1] = new Vector3(200, (percents.NE.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NE.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NE.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NE.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NV Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 40, -50);
        positions[1] = new Vector3(200, (percents.NV.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NV.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NV.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NV.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NH Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 35, -50);
        positions[1] = new Vector3(200, (percents.NH.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NH.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NH.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NH.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NJ Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 30, -50);
        positions[1] = new Vector3(200, (percents.NJ.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NJ.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NJ.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NJ.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NM Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 25, -50);
        positions[1] = new Vector3(200, (percents.NM.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NM.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NM.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NM.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NY Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 20, -50);
        positions[1] = new Vector3(200, (percents.NY.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NY.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NY.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NY.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("NC Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 15, -50);
        positions[1] = new Vector3(200, (percents.NC.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.NC.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.NC.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.NC.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("ND Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 10, -50);
        positions[1] = new Vector3(200, (percents.ND.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.ND.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.ND.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.ND.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("OH Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 5, -50);
        positions[1] = new Vector3(200, (percents.OH.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.OH.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.OH.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.OH.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("OK Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, 0, -50);
        positions[1] = new Vector3(200, (percents.OK.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.OK.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.OK.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.OK.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("OR Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -5, -50);
        positions[1] = new Vector3(200, (percents.OR.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.OR.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.OR.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.OR.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("PA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -10, -50);
        positions[1] = new Vector3(200, (percents.PA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.PA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.PA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.PA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("RI Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -15, -50);
        positions[1] = new Vector3(200, (percents.RI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.RI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.RI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.RI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("SC Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -20, -50);
        positions[1] = new Vector3(200, (percents.SC.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.SC.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.SC.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.SC.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("SD Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -25, -50);
        positions[1] = new Vector3(200, (percents.SD.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.SD.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.SD.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.SD.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("TN Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -30, -50);
        positions[1] = new Vector3(200, (percents.TN.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.TN.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.TN.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.TN.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("TX Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -35, -50);
        positions[1] = new Vector3(200, (percents.TX.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.TX.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.TX.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.TX.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("UT Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -40, -50);
        positions[1] = new Vector3(200, (percents.UT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.UT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.UT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.UT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("VT Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -45, -50);
        positions[1] = new Vector3(200, (percents.VT.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.VT.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.VT.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.VT.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("VA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -50, -50);
        positions[1] = new Vector3(200, (percents.VA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.VA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.VA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.VA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("WA Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -55, -50);
        positions[1] = new Vector3(200, (percents.WA.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WA.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WA.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WA.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("WV Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -60, -50);
        positions[1] = new Vector3(200, (percents.WV.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WV.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WV.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WV.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("WI Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -65, -50);
        positions[1] = new Vector3(200, (percents.WI.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WI.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WI.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WI.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);

        lineObject = GameObject.Find("WY Line");
        line = lineObject.GetComponent<LineRenderer>();
        line.positionCount = 5;
        positions = new Vector3[5];
        positions[0] = new Vector3(200, -70, -50);
        positions[1] = new Vector3(200, (percents.WY.CARCINOGEN * 2) - 50, -150);
        positions[2] = new Vector3(200, (percents.WY.CLEAR_AIR_ACT_CHEMICAL * 2) - 50, -300);
        positions[3] = new Vector3(200, (percents.WY.METAL * 2) - 50, -450);
        positions[4] = new Vector3(200, (percents.WY.FEDERAL_FACILITY * 2) - 50, -600);
        line.SetPositions(positions);
    }
}
