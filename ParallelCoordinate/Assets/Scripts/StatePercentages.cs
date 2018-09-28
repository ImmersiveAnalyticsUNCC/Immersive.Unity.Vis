using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class AllStateReleasePercentages
{
    public  StatePercents WA;
    public  StatePercents DE;
    public  StatePercents DC;
    public  StatePercents WI;
    public  StatePercents WV;
    public  StatePercents FL;
    public  StatePercents WY;
    public  StatePercents NH;
    public  StatePercents NJ;
    public  StatePercents NM;
    public  StatePercents TX;
    public  StatePercents LA;
    public  StatePercents NC;
    public  StatePercents ND;
    public  StatePercents NE;
    public  StatePercents TN;
    public  StatePercents NY;
    public  StatePercents PA;
    public  StatePercents CT;
    public  StatePercents RI;
    public  StatePercents NV;
    public  StatePercents VA;
    public  StatePercents CO;
    public  StatePercents CA;
    public  StatePercents AL;
    public  StatePercents AS;
    public  StatePercents AR;
    public  StatePercents VT;
    public  StatePercents IL;
    public  StatePercents GA;
    public  StatePercents IN;
    public  StatePercents IA;
    public  StatePercents MA;
    public  StatePercents AZ;
    public  StatePercents ID;
    public  StatePercents ME;
    public  StatePercents MD;
    public  StatePercents OK;
    public  StatePercents OH;
    public  StatePercents UT;
    public  StatePercents MO;
    public  StatePercents MN;
    public  StatePercents MI;
    public  StatePercents KS;
    public  StatePercents MT;
    public  StatePercents MS;
    public  StatePercents SC;
    public  StatePercents KY;
    public  StatePercents OR;
    public  StatePercents SD;
    public  StatePercents HI;
    public  StatePercents AK;
    /*
    public static StatePercents[] statePer = new StatePercents[] {AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE,
    NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY};
    */
}

[System.Serializable]
public class StatePercents
{
    public float CLEAR_AIR_ACT_CHEMICAL;
    public float CARCINOGEN;
    public float METAL;
    public float FEDERAL_FACILITY;
    public static int type = 5;
}

public class StatePercentages : MonoBehaviour {

    public int year = 2015;
    public static int t = 0; //1= clearair, 2=carcinogen, 3=Metal, 4=Federal

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
    public Material NorthDakotaMaterial;
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
    /*public Material[] Mats = new Material[] { AlabamaMaterial, AlaskaMaterial, ArizonaMaterial, ArkansasMaterial, CaliforniaMaterial, ColoradoMaterial, ConnecticutMaterial, DelawareMaterial, FloridaMaterial,
        GeorgiaMaterial, HawaiiMaterial, IdahoMaterial, IllinoisMaterial, IndianaMaterial, IowaMaterial, KansasMaterial, KentuckyMaterial, LouisianaMaterial, MaineMaterial, MarylandMaterial, MassachusettsMaterial, MichiganMaterial,
        MinnesotaMaterial, MississippiMaterial, MissouriMaterial, MontanaMaterial, NebraskaMaterial, NevadaMaterial, NewHampshireMaterial, NewJerseyMaterial, NewMexicoMaterial, NewYorkMaterial, NorthCarolinaMaterial,
        NorthDakotaMaterial, OhioMaterial, OklahomaMaterial, OregonMaterial, PennsylvaniaMaterial, RhodeIslandMaterial, SouthCarolinaMaterial, SouthDakotaMaterial, TennesseeMaterial, TexasMaterial, UtahMaterial,
        VermontMaterial, VirginiaMaterial, WashingtonMaterial, WestVirginiaMaterial, WisconsinMaterial, WyomingMaterial};
        */
    private void Awake()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown("right") || Input.GetButtonDown("Gamepad_B"))
        {
            year++;
            if (year > 2015)
            {
                year = 2009;
            }
            Debug.Log("Increased year to: " + year);
            
            if (StatePercents.type == 0)
            {
                ClearActMap();
            } else if (StatePercents.type == 1)
            {
                CarcMap();
            }
            else if (StatePercents.type == 2)
            {
                MetalMap();
            }
            else if (StatePercents.type == 3)
            {
                FederalMap();
            }
        }

        if (Input.GetKeyDown("down") || Input.GetKeyDown("left") || Input.GetButtonDown("Gamepad_X"))
        {
            year--;
            if (year < 2009)
            {
                year = 2015;
            }
            Debug.Log("Decreased year to: " + year);
            if (StatePercents.type == 0)
            {
                ClearActMap();
            }
            else if (StatePercents.type == 1)
            {
                CarcMap();
            }
            else if (StatePercents.type == 2)
            {
                MetalMap();
            }
            else if (StatePercents.type == 3)
            {
                FederalMap();
            }
        }
    }

    void ClearActMap()//blue to yellow
    {
        string dataAsJson = File.ReadAllText("Assets/Data/StatePercentages" + year + ".json");
        AllStateReleasePercentages percents = JsonUtility.FromJson<AllStateReleasePercentages>(dataAsJson);
        //float[] typeArray = {StatePercents.CLEAR_AIR_ACT_CHEMICAL, StatePercents.CARCINOGEN, StatePercents.METAL, StatePercents.FEDERAL_FACILITY};

        //Debug.Log("AK METAL: " + percents.AK.METAL + "%");

        float valueScaled;
        float red;
        float green;
        float blue;

       /*
            //float ty = StatePercents.types[t];
            valueScaled = AllStateReleasePercentages.statePer[i].types[0];
            //valueScaled = percents.AL.CLEAR_AIR_ACT_CHEMICAL;
            if (valueScaled < 50)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 50) * 255;
                 = new Color(red, green, blue, 1);
            }
            else if (valueScaled == 50)
            {
                red = 0;
                green = 0;
                blue = 0;
                 = new Color(red, green, blue, 1);
            }
            else if (valueScaled > 50)
            {
                red = 255 * ((valueScaled - 50) / 50);
                green = 255 * ((valueScaled - 50) / 50);
                blue = 0;
                 = new Color(red, green, blue, 1);
            }
           */ 
        

        
        valueScaled = percents.AL.CLEAR_AIR_ACT_CHEMICAL;
        if(valueScaled < 13)//black
        {
            red = 0;
            green = 0;
            blue = 0;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else if(valueScaled > 73)//white
        {
            red = 255;
            green = 255;
            blue = 255;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {//between 
            //red = (valueScaled/73) * 255;
            //green = (valueScaled/73) * 255;
            //blue = 255 - ((valueScaled/73) * 255);
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled/73) * 255;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled/73) * 255;
                green = (valueScaled/73) * 255;
                blue = 0;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
            
        }
        //Debug.Log("Alabama:" + valueScaled);
        //AlabamaMaterial.color = new Color(red, green, blue, 1);
        valueScaled = percents.AK.CLEAR_AIR_ACT_CHEMICAL;
        if(valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //AlaskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        //AlaskaMaterial.color = new Color(0, 0, 255, 1);
        valueScaled = percents.AZ.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArizonaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.AR.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArkansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CA.CLEAR_AIR_ACT_CHEMICAL;

        if (valueScaled < 13)
            {
                red = 0;
                green = 0;
                blue = 0;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //CaliforniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CO.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ColoradoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CT.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ConnecticutMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.DE.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //DelawareMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.FL.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //FloridaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.GA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //GeorgiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.HI.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //HawaiiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ID.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IdahoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IL.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IllinoisMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IN.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IndianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IowaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KS.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KY.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KentuckyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.LA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //LouisianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ME.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MaineMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MD.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MarylandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MassachusettsMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MI.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MichiganMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MN.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MinnesotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MS.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MississippiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MO.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MissouriMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MT.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MontanaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NE.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NebraskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NV.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NevadaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NH.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewHampshireMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NJ.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewJerseyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NM.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewMexicoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NY.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewYorkMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NC.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ND.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OH.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OhioMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OK.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OklahomaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OR.CLEAR_AIR_ACT_CHEMICAL;
        Debug.Log("Oregon: " + valueScaled);
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OregonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.PA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //PennsylvaniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.RI.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //RhodeIslandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SC.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SD.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TN.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
               TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TennesseeMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TX.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TexasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.UT.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //UtahMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VT.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VermontMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WA.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WashingtonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WV.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WestVirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WI.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WisconsinMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WY.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 73)
        {
            red = 255;
            green = 255;
            blue = 255;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 43)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 73) * 255;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 73) * 255;
                green = (valueScaled / 73) * 255;
                blue = 0;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WyomingMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);

    }

    void CarcMap()//blue to magenta
    {
        string dataAsJson = File.ReadAllText("Assets/Data/StatePercentages" + year + ".json");
        AllStateReleasePercentages percents = JsonUtility.FromJson<AllStateReleasePercentages>(dataAsJson);
        //float[] typeArray = {StatePercents.CLEAR_AIR_ACT_CHEMICAL, StatePercents.CARCINOGEN, StatePercents.METAL, StatePercents.FEDERAL_FACILITY};

        //Debug.Log("AK METAL: " + percents.AK.METAL + "%");

        float valueScaled;
        float red;
        float green;
        float blue;
 
        valueScaled = percents.AL.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //Debug.Log("Alabama:" + valueScaled);
        //AlabamaMaterial.color = new Color(red, green, blue, 1);
        valueScaled = percents.AK.CARCINOGEN;
        if (valueScaled < 50)
            if (valueScaled < .2)
            {
                red = 0;
                green = 0;
                blue = 0;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
            else if (valueScaled > 11)
            {
                red = 255;
                green = 255;
                blue = 255;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                if (valueScaled <= 6)
                {
                    red = 0;
                    green = 0;
                    blue = (valueScaled / 6) * 255;
                    AlaskaMaterial.color = new Color(red, green, blue, 1);
                }
                else
                {
                    red = (valueScaled / 6) * 255;
                    green = 0;
                    blue = (valueScaled / 6) * 255;
                    AlaskaMaterial.color = new Color(red, green, blue, 1);
                }
            }
        //AlaskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        //AlaskaMaterial.color = new Color(0, 0, 255, 1);
        valueScaled = percents.AZ.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArizonaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.AR.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArkansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //CaliforniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CO.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ColoradoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CT.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ConnecticutMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.DE.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //DelawareMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.FL.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //FloridaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.GA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //GeorgiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.HI.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //HawaiiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ID.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IdahoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IL.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IllinoisMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IN.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IndianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IowaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KS.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KY.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KentuckyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.LA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //LouisianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ME.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MaineMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1); 
        valueScaled = percents.MD.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MarylandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MassachusettsMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MI.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MichiganMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MN.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MinnesotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MS.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MississippiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MO.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MissouriMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MT.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MontanaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NE.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NebraskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NV.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NevadaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NH.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewHampshireMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NJ.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewJerseyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NM.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewMexicoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NY.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewYorkMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NC.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ND.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OH.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OhioMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OK.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OklahomaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OR.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OregonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.PA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //PennsylvaniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.RI.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //RhodeIslandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SC.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SD.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TN.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TennesseeMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TX.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TexasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.UT.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //UtahMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VT.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VermontMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WA.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WashingtonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WV.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WestVirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WI.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WisconsinMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WY.CARCINOGEN;
        if (valueScaled < .2)
        {
            red = 0;
            green = 0;
            blue = 0;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 11)
        {
            red = 255;
            green = 255;
            blue = 255;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 6)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 6) * 255;
                green = 0;
                blue = (valueScaled / 6) * 255;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
        }
    }

    void MetalMap()//blue to cyan //add green keep blue at 255
    {
        string dataAsJson = File.ReadAllText("Assets/Data/StatePercentages" + year + ".json");
        AllStateReleasePercentages percents = JsonUtility.FromJson<AllStateReleasePercentages>(dataAsJson);
        //float[] typeArray = {StatePercents.CLEAR_AIR_ACT_CHEMICAL, StatePercents.CARCINOGEN, StatePercents.METAL, StatePercents.FEDERAL_FACILITY};

        //Debug.Log("AK METAL: " + percents.AK.METAL + "%");

        /*
 valueScaled = percents.AK.CLEAR_AIR_ACT_CHEMICAL;
 if (valueScaled < 13)
 {
     red = 0;
     green = 0;
     blue = 0;
     AlaskaMaterial.color = new Color(red, green, blue, 1);
 }
 else if (valueScaled > 45)
 {
     red = 255;
     green = 255;
     blue = 255;
     AlaskaMaterial.color = new Color(red, green, blue, 1);
 }
 else
 {
     if (valueScaled <= 37)
     {
         red = 0;
         green = 0;
         blue = (valueScaled / 37) * 255;
         AlaskaMaterial.color = new Color(red, green, blue, 1);
     }
     else
     {
         red = (valueScaled / 37) * 255;
         green = 0;
         blue = (valueScaled / 37) * 255;
         AlaskaMaterial.color = new Color(red, green, blue, 1);
     }
 }
 */

        float valueScaled;
        float red;
        float green;
        float blue;

        valueScaled = percents.AL.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //Debug.Log("Alabama:" + valueScaled);
        //AlabamaMaterial.color = new Color(red, green, blue, 1);
        valueScaled = percents.AK.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //AlaskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        //AlaskaMaterial.color = new Color(0, 0, 255, 1);
        valueScaled = percents.AZ.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArizonaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.AR.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArkansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //CaliforniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CO.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ColoradoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CT.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ConnecticutMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.DE.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //DelawareMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.FL.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //FloridaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.GA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //GeorgiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.HI.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //HawaiiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ID.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IdahoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IL.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IllinoisMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IN.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IndianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IowaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KS.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KY.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KentuckyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.LA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //LouisianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ME.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MaineMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1); 
        valueScaled = percents.MD.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MarylandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MassachusettsMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MI.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MichiganMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MN.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MinnesotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MS.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MississippiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MO.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MissouriMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MT.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MontanaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NE.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NebraskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NV.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NevadaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NH.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewHampshireMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NJ.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewJerseyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NM.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewMexicoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NY.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewYorkMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NC.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ND.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OH.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OhioMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OK.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OklahomaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OR.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OregonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.PA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //PennsylvaniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.RI.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //RhodeIslandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SC.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SD.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TN.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TennesseeMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TX.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TexasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.UT.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //UtahMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VT.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VermontMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WA.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WashingtonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WV.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WestVirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WI.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WisconsinMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WY.METAL;
        if (valueScaled < 13)
        {
            red = 0;
            green = 0;
            blue = 0;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 61)
        {
            red = 255;
            green = 255;
            blue = 255;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 37)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 37) * 255;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = 0;
                green = (valueScaled / 37) * 255;
                blue = (valueScaled / 37) * 255;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
        }
    }

    void FederalMap()//blue to red // keep blue 255 add to red and green
    {
        string dataAsJson = File.ReadAllText("Assets/Data/StatePercentages" + year + ".json");
        AllStateReleasePercentages percents = JsonUtility.FromJson<AllStateReleasePercentages>(dataAsJson);
        //float[] typeArray = {StatePercents.CLEAR_AIR_ACT_CHEMICAL, StatePercents.CARCINOGEN, StatePercents.METAL, StatePercents.FEDERAL_FACILITY};

        //Debug.Log("AK METAL: " + percents.AK.METAL + "%");

        /*
        valueScaled = percents.AK.CLEAR_AIR_ACT_CHEMICAL;
        if (valueScaled < 0)
            {
            red = 0;
            green = 0;
            blue = 0;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
        else if (valueScaled > 7.5)
            {
            red = 255;
            green = 255;
            blue = 255;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
        else
            {
            if (valueScaled <= 4)
                {
                 red = 0;
                 green = 0;
                 blue = (valueScaled / 4) * 255;
                 AlaskaMaterial.color = new Color(red, green, blue, 1);
                }
            else
                {
                 red = (valueScaled / 4) * 255;
                 green = 0;
                 blue = (valueScaled / 4) * 255;
                 AlaskaMaterial.color = new Color(red, green, blue, 1);
                }
        }
        */

        float valueScaled;
        float red;
        float green;
        float blue;

        valueScaled = percents.AL.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            AlabamaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                AlabamaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //Debug.Log("Alabama:" + valueScaled);
        //AlabamaMaterial.color = new Color(red, green, blue, 1);
        valueScaled = percents.AK.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            AlaskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                AlaskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //AlaskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        //AlaskaMaterial.color = new Color(0, 0, 255, 1);
        valueScaled = percents.AZ.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArizonaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                ArizonaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArizonaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.AR.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            ArkansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                ArkansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ArkansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            CaliforniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                CaliforniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //CaliforniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CO.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            ColoradoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                ColoradoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ColoradoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.CT.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            ConnecticutMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                ConnecticutMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //ConnecticutMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.DE.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            DelawareMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                DelawareMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //DelawareMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.FL.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            FloridaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                FloridaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //FloridaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.GA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            GeorgiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                GeorgiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //GeorgiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.HI.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            HawaiiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                HawaiiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //HawaiiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ID.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            IdahoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                IdahoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IdahoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IL.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            IllinoisMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                IllinoisMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IllinoisMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IN.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            IndianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                IndianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IndianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.IA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            IowaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                IowaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //IowaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KS.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            KansasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                KansasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KansasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.KY.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            KentuckyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                KentuckyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //KentuckyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.LA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            LouisianaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                LouisianaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //LouisianaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ME.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MaineMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MaineMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MaineMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1); 
        valueScaled = percents.MD.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MarylandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MarylandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MarylandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MassachusettsMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MassachusettsMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MassachusettsMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MI.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MichiganMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MichiganMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MichiganMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MN.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MinnesotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MinnesotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MinnesotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MS.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MississippiMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MississippiMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MississippiMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MO.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MissouriMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MissouriMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MissouriMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.MT.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            MontanaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                MontanaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //MontanaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NE.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NebraskaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NebraskaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NebraskaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NV.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NevadaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NevadaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NevadaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NH.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewHampshireMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NewHampshireMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewHampshireMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NJ.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewJerseyMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NewJerseyMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewJerseyMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NM.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewMexicoMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NewMexicoMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewMexicoMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NY.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NewYorkMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NewYorkMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NewYorkMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.NC.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NorthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.ND.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            NorthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                NorthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //NorthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OH.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            OhioMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                OhioMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OhioMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OK.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            OklahomaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                OklahomaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OklahomaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.OR.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            OregonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                OregonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //OregonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.PA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                PennsylvaniaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //PennsylvaniaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.RI.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            RhodeIslandMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                RhodeIslandMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //RhodeIslandMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SC.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                SouthCarolinaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthCarolinaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.SD.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            SouthDakotaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                SouthDakotaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //SouthDakotaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TN.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            TennesseeMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                TennesseeMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TennesseeMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.TX.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            TexasMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                TexasMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //TexasMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.UT.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            UtahMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                UtahMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //UtahMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VT.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            VermontMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                VermontMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VermontMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.VA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            VirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                VirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //VirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WA.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            WashingtonMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                WashingtonMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WashingtonMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WV.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            WestVirginiaMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                WestVirginiaMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WestVirginiaMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WI.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            WisconsinMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                WisconsinMaterial.color = new Color(red, green, blue, 1);
            }
        }
        //WisconsinMaterial.color = new Color(valueScaled, valueScaled, 255 - valueScaled, 1);
        valueScaled = percents.WY.FEDERAL_FACILITY;
        if (valueScaled < 0)
        {
            red = 0;
            green = 0;
            blue = 0;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else if (valueScaled > 7.5)
        {
            red = 255;
            green = 255;
            blue = 255;
            WyomingMaterial.color = new Color(red, green, blue, 1);
        }
        else
        {
            if (valueScaled <= 4)
            {
                red = 0;
                green = 0;
                blue = (valueScaled / 4) * 255;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
            else
            {
                red = (valueScaled / 4) * 255;
                green = 0;
                blue = 0;
                WyomingMaterial.color = new Color(red, green, blue, 1);
            }
        }
    }
}
