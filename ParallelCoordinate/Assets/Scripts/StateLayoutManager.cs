using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class StateInfo
{
    public float WA;
    public float DE;
    public float DC;
    public float WI;
    public float WV;
    public float FL;
    public float WY;
    public float NH;
    public float NJ;
    public float NM;
    public float TX;
    public float LA;
    public float NC;
    public float ND;
    public float NE;
    public float TN;
    public float NY;
    public float PA;
    public float CT;
    public float RI;
    public float NV;
    public float VA;
    public float CO;
    public float CA;
    public float AL;
    public float AS;
    public float AR;
    public float VT;
    public float IL;
    public float GA;
    public float IN;
    public float IA;
    public float MA;
    public float AZ;
    public float ID;
    public float ME;
    public float MD;
    public float OK;
    public float OH;
    public float UT;
    public float MO;
    public float MN;
    public float MI;
    public float KS;
    public float MT;
    public float MS;
    public float SC;
    public float KY;
    public float OR;
    public float SD;
    public float HI;
    public float AK;
}

public class StateLayoutManager : MonoBehaviour {

    //Year
    public static int year = 2015;
    public Text currentYearText;
    public Transform yearSliderBox;

    // Transforms
    public Transform Alabama;
    public Transform Alaska;
    public Transform Arizona;
    public Transform Arkansas;
    public Transform California;
    public Transform Colorado;
    public Transform Connecticut;
    public Transform Delaware;
    public Transform Florida;
    public Transform Georgia;
    public Transform Hawaii;
    public Transform Idaho;
    public Transform Illinois;
    public Transform Indiana;
    public Transform Iowa;
    public Transform Kansas;
    public Transform Kentucky;
    public Transform Louisiana;
    public Transform Maine;
    public Transform Maryland;
    public Transform Massachusetts;
    public Transform Michigan;
    public Transform Minnesota;
    public Transform Mississippi;
    public Transform Missouri;
    public Transform Montana;
    public Transform Nebraska;
    public Transform Nevada;
    public Transform NewHampshire;
    public Transform NewJersey;
    public Transform NewMexico;
    public Transform NewYork;
    public Transform NorthCarolina;
    public Transform NothDakota;
    public Transform Ohio;
    public Transform Oklahoma;
    public Transform Oregon;
    public Transform Pennsylvania;
    public Transform RhodeIsland;
    public Transform SouthCarolina;
    public Transform SouthDakota;
    public Transform Tennessee;
    public Transform Texas;
    public Transform Utah;
    public Transform Vermont;
    public Transform Virginia;
    public Transform Washington;
    public Transform WestVirginia;
    public Transform Wisconsin;
    public Transform Wyoming;

    //Materials
    public Material AlabamaMaterial;
    public Material AlaskaMaterial;
    public Material ArizonaMaterial;
    public Material ArkansasMaterial;
    public Material CaliforniaMaterial;
    public Material ColoradoMaterial;
    public Material ConnecticutMaterial;
    public Material DelawareMaterial;
    public Material FloridaMaterial;
    public Material GeorgiaMaterial;
    public Material HawaiiMaterial;
    public Material IdahoMaterial;
    public Material IllinoisMaterial;
    public Material IndianaMaterial;
    public Material IowaMaterial;
    public Material KansasMaterial;
    public Material KentuckyMaterial;
    public Material LouisianaMaterial;
    public Material MaineMaterial;
    public Material MarylandMaterial;
    public Material MassachusettsMaterial;
    public Material MichiganMaterial;
    public Material MinnesotaMaterial;
    public Material MississippiMaterial;
    public Material MissouriMaterial;
    public Material MontanaMaterial;
    public Material NebraskaMaterial;
    public Material NevadaMaterial;
    public Material NewHampshireMaterial;
    public Material NewJerseyMaterial;
    public Material NewMexicoMaterial;
    public Material NewYorkMaterial;
    public Material NorthCarolinaMaterial;
    public Material NothDakotaMaterial;
    public Material OhioMaterial;
    public Material OklahomaMaterial;
    public Material OregonMaterial;
    public Material PennsylvaniaMaterial;
    public Material RhodeIslandMaterial;
    public Material SouthCarolinaMaterial;
    public Material SouthDakotaMaterial;
    public Material TennesseeMaterial;
    public Material TexasMaterial;
    public Material UtahMaterial;
    public Material VermontMaterial;
    public Material VirginiaMaterial;
    public Material WashingtonMaterial;
    public Material WestVirginiaMaterial;
    public Material WisconsinMaterial;
    public Material WyomingMaterial;

    public ChemicalGraph upper;
    public ChemicalGraph mid;
    public ChemicalGraph lower;

    private void Awake()
    {
        RefreshMap();
    }

    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown("right") || Input.GetButtonDown("Gamepad_B"))
        {
            year++;
            if (year > 2015)
            {
                year = 2009;
                yearSliderBox.position = new Vector3(-220, yearSliderBox.position.y, yearSliderBox.position.z);
                currentYearText.transform.position = currentYearText.transform.position - new Vector3(380, 0, 0);
            }
            else
            {
                yearSliderBox.position = yearSliderBox.position + new Vector3((380f / 6f), 0, 0);
                currentYearText.transform.position = currentYearText.transform.position + new Vector3((380f / 6f), 0, 0);
            }
            Debug.Log("Increased year to: " + year);
            RefreshMap();
            ParallelCoordinates.Update();
            if (upper.generated)
            {
                upper.RefreshGraph();
            }
            if (mid.generated)
            {
                mid.RefreshGraph();
            }
            if (lower.generated)
            {
                lower.RefreshGraph();
            }
        }

        if (Input.GetKeyDown("down") || Input.GetKeyDown("left") || Input.GetButtonDown("Gamepad_X"))
        {
            year--;
            if (year < 2009)
            {
                year = 2015;
                yearSliderBox.position = new Vector3(160, yearSliderBox.position.y, yearSliderBox.position.z);
                currentYearText.transform.position = currentYearText.transform.position + new Vector3(380, 0, 0);
            }
            else
            {
                yearSliderBox.position = yearSliderBox.position - new Vector3((380f / 6f), 0, 0);
                currentYearText.transform.position = currentYearText.transform.position - new Vector3((380f / 6f), 0, 0);
            }
            Debug.Log("Decreased year to: " + year);
            RefreshMap();
            ParallelCoordinates.Update();
            if (upper.generated)
            {
                upper.RefreshGraph();
            }
            if (mid.generated)
            {
                mid.RefreshGraph();
            }
            if (lower.generated)
            {
                lower.RefreshGraph();
            }
        }
    }

    void RefreshMap()
    {
        currentYearText.text = "" + year;
        string dataAsJson = File.ReadAllText("Assets/Data/StateHeights" + year + ".json");
        StateInfo heights = JsonUtility.FromJson<StateInfo>(dataAsJson);

        // Set State Z positions based on height
        Alabama.transform.localScale = new Vector3(Alabama.transform.localScale.x, Alabama.transform.localScale.y, heights.AL);
        Alaska.transform.localScale = new Vector3(Alaska.transform.localScale.x, Alaska.transform.localScale.y, heights.AS);
        Arizona.transform.localScale = new Vector3(Arizona.transform.localScale.x, Arizona.transform.localScale.y, heights.AZ);
        Arkansas.transform.localScale = new Vector3(Arkansas.transform.localScale.x, Arkansas.transform.localScale.y, heights.AR);
        California.transform.localScale = new Vector3(California.transform.localScale.x, California.transform.localScale.y, heights.CA);
        Colorado.transform.localScale = new Vector3(Colorado.transform.localScale.x, Colorado.transform.localScale.y, heights.CO);
        Connecticut.transform.localScale = new Vector3(Connecticut.transform.localScale.x, Connecticut.transform.localScale.y, heights.CT);
        Delaware.transform.localScale = new Vector3(Delaware.transform.localScale.x, Delaware.transform.localScale.y, heights.DE);
        Florida.transform.localScale = new Vector3(Florida.transform.localScale.x, Florida.transform.localScale.y, heights.FL);
        Georgia.transform.localScale = new Vector3(Georgia.transform.localScale.x, Georgia.transform.localScale.y, heights.GA);
        Hawaii.transform.localScale = new Vector3(Hawaii.transform.localScale.x, Hawaii.transform.localScale.y, heights.HI);
        Idaho.transform.localScale = new Vector3(Idaho.transform.localScale.x, Idaho.transform.localScale.y, heights.ID);
        Illinois.transform.localScale = new Vector3(Illinois.transform.localScale.x, Illinois.transform.localScale.y, heights.IL);
        Indiana.transform.localScale = new Vector3(Indiana.transform.localScale.x, Indiana.transform.localScale.y, heights.IN);
        Iowa.transform.localScale = new Vector3(Iowa.transform.localScale.x, Iowa.transform.localScale.y, heights.IA);
        Kansas.transform.localScale = new Vector3(Kansas.transform.localScale.x, Kansas.transform.localScale.y, heights.KS);
        Kentucky.transform.localScale = new Vector3(Kentucky.transform.localScale.x, Kentucky.transform.localScale.y, heights.KY);
        Louisiana.transform.localScale = new Vector3(Louisiana.transform.localScale.x, Louisiana.transform.localScale.y, heights.LA);
        Maine.transform.localScale = new Vector3(Maine.transform.localScale.x, Maine.transform.localScale.y, heights.ME);
        Maryland.transform.localScale = new Vector3(Maryland.transform.localScale.x, Maryland.transform.localScale.y, heights.MD);
        Massachusetts.transform.localScale = new Vector3(Massachusetts.transform.localScale.x, Massachusetts.transform.localScale.y, heights.MA);
        Michigan.transform.localScale = new Vector3(Michigan.transform.localScale.x, Michigan.transform.localScale.y, heights.MI);
        Minnesota.transform.localScale = new Vector3(Minnesota.transform.localScale.x, Minnesota.transform.localScale.y, heights.MN);
        Mississippi.transform.localScale = new Vector3(Mississippi.transform.localScale.x, Mississippi.transform.localScale.y, heights.MS);
        Missouri.transform.localScale = new Vector3(Missouri.transform.localScale.x, Missouri.transform.localScale.y, heights.MO);
        Montana.transform.localScale = new Vector3(Montana.transform.localScale.x, Montana.transform.localScale.y, heights.MT);
        Nebraska.transform.localScale = new Vector3(Nebraska.transform.localScale.x, Nebraska.transform.localScale.y, heights.NE);
        Nevada.transform.localScale = new Vector3(Nevada.transform.localScale.x, Nevada.transform.localScale.y, heights.NV);
        NewHampshire.transform.localScale = new Vector3(NewHampshire.transform.localScale.x, NewHampshire.transform.localScale.y, heights.NH);
        NewJersey.transform.localScale = new Vector3(NewJersey.transform.localScale.x, NewJersey.transform.localScale.y, heights.NJ);
        NewMexico.transform.localScale = new Vector3(NewMexico.transform.localScale.x, NewMexico.transform.localScale.y, heights.NM);
        NewYork.transform.localScale = new Vector3(NewYork.transform.localScale.x, NewYork.transform.localScale.y, heights.NY);
        NorthCarolina.transform.localScale = new Vector3(NorthCarolina.transform.localScale.x, NorthCarolina.transform.localScale.y, heights.NC);
        NothDakota.transform.localScale = new Vector3(NothDakota.transform.localScale.x, NothDakota.transform.localScale.y, heights.ND);
        Ohio.transform.localScale = new Vector3(Ohio.transform.localScale.x, Ohio.transform.localScale.y, heights.OH);
        Oklahoma.transform.localScale = new Vector3(Oklahoma.transform.localScale.x, Oklahoma.transform.localScale.y, heights.OK);
        Oregon.transform.localScale = new Vector3(Oregon.transform.localScale.x, Oregon.transform.localScale.y, heights.OR);
        Pennsylvania.transform.localScale = new Vector3(Pennsylvania.transform.localScale.x, Pennsylvania.transform.localScale.y, heights.PA);
        RhodeIsland.transform.localScale = new Vector3(RhodeIsland.transform.localScale.x, RhodeIsland.transform.localScale.y, heights.RI);
        SouthCarolina.transform.localScale = new Vector3(SouthCarolina.transform.localScale.x, SouthCarolina.transform.localScale.y, heights.SC);
        SouthDakota.transform.localScale = new Vector3(SouthDakota.transform.localScale.x, SouthDakota.transform.localScale.y, heights.SD);
        Tennessee.transform.localScale = new Vector3(Tennessee.transform.localScale.x, Tennessee.transform.localScale.y, heights.TN);
        Texas.transform.localScale = new Vector3(Texas.transform.localScale.x, Texas.transform.localScale.y, heights.TX);
        Utah.transform.localScale = new Vector3(Utah.transform.localScale.x, Utah.transform.localScale.y, heights.UT);
        Vermont.transform.localScale = new Vector3(Vermont.transform.localScale.x, Vermont.transform.localScale.y, heights.VT);
        Virginia.transform.localScale = new Vector3(Virginia.transform.localScale.x, Virginia.transform.localScale.y, heights.VA);
        Washington.transform.localScale = new Vector3(Washington.transform.localScale.x, Washington.transform.localScale.y, heights.WA);
        WestVirginia.transform.localScale = new Vector3(WestVirginia.transform.localScale.x, WestVirginia.transform.localScale.y, heights.WV);
        Wisconsin.transform.localScale = new Vector3(Wisconsin.transform.localScale.x, Wisconsin.transform.localScale.y, heights.WI);
        Wyoming.transform.localScale = new Vector3(Wyoming.transform.localScale.x, Wyoming.transform.localScale.y, heights.WY);

        // Set State colors based on height
        int min_color = 0;
        int max_color = 255;

        int min_height = 10;
        int max_height = 30;

        float valueScaled;
        float red;
        float green;

        valueScaled = (heights.AL - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        AlabamaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.AK - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        AlaskaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.AZ - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        ArizonaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.AR - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        ArkansasMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.CA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        CaliforniaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.CO - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        ColoradoMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.CT - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        ConnecticutMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.DE - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        DelawareMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.FL - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        FloridaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.GA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        GeorgiaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.ID - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        HawaiiMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.HI - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        IdahoMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.IL - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        IllinoisMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.IN - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        IndianaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.IA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        IowaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.KS - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        KansasMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.KY - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        KentuckyMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.LA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        LouisianaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.ME - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MaineMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MD - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MarylandMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MassachusettsMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MI - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MichiganMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MN - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MinnesotaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MS - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MississippiMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MO - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MissouriMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.MT - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        MontanaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NE - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NebraskaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NV - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NevadaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NH - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NewHampshireMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NJ - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NewJerseyMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NM - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NewMexicoMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NY - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NewYorkMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.NC - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NorthCarolinaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.ND - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        NothDakotaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.OH - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        OhioMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.OK - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        OklahomaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.OR - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        OregonMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.PA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        PennsylvaniaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.RI - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        RhodeIslandMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.SC - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        SouthCarolinaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.SD - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        SouthDakotaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.TN - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        TennesseeMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.TX - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        TexasMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.UT - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        UtahMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.VT - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        VermontMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.VA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        VirginiaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.WA - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        WashingtonMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.WV - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        WestVirginiaMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.WI - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        WisconsinMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
        valueScaled = (heights.WY - min_height) / (max_height - min_height);
        red = min_color + (valueScaled * max_color);
        green = 255 - red;
        WyomingMaterial.color = new Color(red / 255.0f, green / 255.0f, 0, 1);
    }
}
