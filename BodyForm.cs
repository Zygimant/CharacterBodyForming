using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BodyForm : MonoBehaviour
{
    public bool BodyMinMaxSet = false;
    public bool BodyFormed = false;

    public int[] race = {1, 0};
    public bool female = true;
    public float femininity = 1f;
    public float femininityToSet = 1f;

    [Header("Body Sliders")]
    public float BodySize = 0.2f;
    public float TorsoLenght = 0f;
    public float ArmSize = 1f;
    public float ShoulderWidth = 0f;
    public float ShoulderPoseX = 0f;
    public float ChestSize = 1f;
    public float WaistSize = 1f;
    public float HipSize = 1f;
    public float LegLenght = 0f;

    public float HipWidth = 0f;
    public float HipPlaceX = 0f;
    public float LLegsPlaceX = 0f;
    public float RLegsPlaceX = 0f;

    public float HeadSize = 0.94f;
    public float JawSize = 1f;
    public float JawWidth = 1f;
    public float JawPlaceY = 0f;

    [Header("Face Parts Spr Nr")]
    public int EyebrowNr = 0;
    public int EyesMainNr = 0;
    public int EyesIrisNr = 0;
    public int EyesPupilNr = 0;
    public int NoseNr = 0;
    public int MouthNr = 0;

    [Header("Body Colors")]
    public Color skinColor;
    public Color hairColor;
    public Color eyeIrisColor;

    public float SkinHue;
    public float SkinTone;
    public float SkinExtraSatr;
    public float SkinExtraValue;


    //References to all the gameobjects to manage
    [Header("Body Parts")]
    public GameObject Head;
    public GameObject JawBone;
    public GameObject Jaw;
    public GameObject[] Spine;
    public GameObject[] LArm;
    public GameObject[] RArm;
    public GameObject[] LArmBones;
    public GameObject[] RArmBones;
    public GameObject LHand;
    public GameObject RHand;
    public GameObject Chest;
    public GameObject Waist;
    public GameObject[] LLeg;
    public GameObject[] RLeg;
    public GameObject[] LLegBones;
    public GameObject[] RLegBones;
    public GameObject LFoot;
    public GameObject RFoot;

    public GameObject[] skinParts;
    public GameObject[] otherBParts;

    public GameObject attentionTarget;


    //Races: Male
    //Humans, Baset, Talen, Fktik, Lurek, Lamnp
    private float[] raceMaxBodySize = { 0.21f, 0.25f };
    private float[] raceMinBodySize = { 0.19f, 0.15f };
    private float[] raceMaxJawSize = { 1.35f, 1.3f };
    private float[] raceMinJawSize = { 0.65f, 0.7f };
    private float[] raceMaxJawPlaceY = { 0.5f, 1.5f };
    private float[] raceMinJawPlaceY = { -0.3f, -1.5f };
    private float[] raceMaxTorsoLenght = { 1f, 1.5f };
    private float[] raceMinTorsoLenght = { -2f, -6f };
    private float[] raceMaxArmSize = { 1.15f, 1.75f };
    private float[] raceMinArmSize = { 0.84f, 0.6f };
    private float[] raceMaxShoulderWidth = { 0.4f, 1.3f };
    private float[] raceMinShoulderWidth = { -1f, 0.8f };
    private float[] raceMaxShoulderPoseX = { 0.4f, 1.3f };
    private float[] raceMinShoulderPoseX = { -0.15f, 0.8f };
    private float[] raceMaxChestSize = { 1.1f, 1.3f };
    private float[] raceMinChestSize = { 0.97f, 0.8f };
    private float[] raceMaxWaistSize = { 1.08f, 1.8f };
    private float[] raceMinWaistSize = { 0.9f, 0.7f };
    private float[] raceMaxHipWidth = { 0.4f, 1.4f };
    private float[] raceMinHipWidth = { -0.4f, 0.6f };
    private float[] raceMaxHipSize = { 1.2f, 1.4f };
    private float[] raceMinHipSize = { 0.8f, 0.6f };
    private float[] raceMaxHipPlaceX = { 0.2f, 1.4f };
    private float[] raceMinHipPlaceX = { -0.4f, 0.6f };
    private float[] raceMaxLegLenght = { 1f, 1.3f };
    private float[] raceMinLegLenght = { -1f, -10f };
    private float[] raceMaxSkinHue = { 360f, 360f };
    private float[] raceMinSkinHue = { 0, 0 };
    private float[] raceMaxSkinTone = { 50f, 50f };
    private float[] raceMinSkinTone = { 0, 0 };
    private float[] raceMaxSkinExtraSatr = { 25f, 100f };
    private float[] raceMinSkinExtraSatr = { -25f, -100f };
    private float[] raceMaxSkinExtraValue = { 25f, 100f };
    private float[] raceMinSkinExtraValue = { -25f, -100f };

    //Races: Female
    //Humans, Baset, Talen, Fktik, Lurek, Lamnp
    private float[] raceMaxBodySizeF = { 0.21f, 0.25f };
    private float[] raceMinBodySizeF = { 0.19f, 0.15f };
    private float[] raceMaxJawSizeF = { 1.35f, 1.3f };
    private float[] raceMinJawSizeF = { 0.65f, 0.7f };
    private float[] raceMaxJawPlaceYF = { 0.5f, 1.5f };
    private float[] raceMinJawPlaceYF = { -0.3f, -1.5f };
    private float[] raceMaxTorsoLenghtF = { 1f, 1.5f };
    private float[] raceMinTorsoLenghtF = { -2f, -6f };
    private float[] raceMaxArmSizeF = { 1.15f, 1.75f };
    private float[] raceMinArmSizeF = { 0.84f, 0.6f };
    private float[] raceMaxShoulderWidthF = { 0.4f, 1.3f };
    private float[] raceMinShoulderWidthF = { -1f, 0.8f };
    private float[] raceMaxShoulderPoseXF = { 0.4f, 1.3f };
    private float[] raceMinShoulderPoseXF = { -0.15f, 0.8f };
    private float[] raceMaxChestSizeF = { 1.1f, 1.3f };
    private float[] raceMinChestSizeF = { 0.97f, 0.8f };
    private float[] raceMaxWaistSizeF = { 1.08f, 1.8f };
    private float[] raceMinWaistSizeF = { 0.9f, 0.7f };
    private float[] raceMaxHipWidthF = { 0.4f, 1.4f };
    private float[] raceMinHipWidthF = { -0.4f, 0.6f };
    private float[] raceMaxHipSizeF = { 1.2f, 1.4f };
    private float[] raceMinHipSizeF = { 0.8f, 0.6f };
    private float[] raceMaxHipPlaceXF = { 0.2f, 1.4f };
    private float[] raceMinHipPlaceXF = { -0.4f, 0.6f };
    private float[] raceMaxLegLenghtF = { 1f, 1.3f };
    private float[] raceMinLegLenghtF = { -1f, -10f };
    private float[] raceMaxSkinHueF = { 360f, 360f };
    private float[] raceMinSkinHueF = { 0, 0 };
    private float[] raceMaxSkinToneF = { 50f, 50f };
    private float[] raceMinSkinToneF = { 0, 0 };
    private float[] raceMaxSkinExtraSatrF = { 25f, 25f };
    private float[] raceMinSkinExtraSatrF = { -25f, -25f };
    private float[] raceMaxSkinExtraValueF = { 25f, 25f };
    private float[] raceMinSkinExtraValueF = { -25f, -25f };

    [Header("Min Max Body attributes")]
    public int raceSum = 0;
    public float TotalMaxBodySize = 0;
    public float TotalMinBodySize = 0;
    public float TotalMaxTorsoLenght = 0;
    public float TotalMinTorsoLenght = 0;
    public float TotalMaxArmSize = 0;
    public float TotalMinArmSize = 0;
    public float TotalMaxShoulderWidth = 0;
    public float TotalMinShoulderWidth = 0;
    public float TotalMaxShoulderPoseX = 0;
    public float TotalMinShoulderPoseX = 0;
    public float TotalMaxChestSize = 0;
    public float TotalMinChestSize = 0;
    public float TotalMaxWaistSize = 0;
    public float TotalMinWaistSize = 0;
    public float TotalMaxHipSize = 0;
    public float TotalMinHipSize = 0;
    public float TotalMaxLegLenght = 0;
    public float TotalMinLegLenght = 0;
    public float TotalMaxHipWidth = 0;
    public float TotalMinHipWidth = 0;
    public float TotalMaxHipPlaceX = 0;
    public float TotalMinHipPlaceX = 0;
    public float TotalMaxJawSize = 0;
    public float TotalMinJawSize = 0;
    public float TotalMaxJawPlaceY = 0;
    public float TotalMinJawPlaceY = 0;
    public float TotalMaxSkinHue = 0;
    public float TotalMinSkinHue = 0;
    public float TotalMaxSkinTone = 0;
    public float TotalMinSkinTone = 0;
    public float TotalMaxSkinExtraSatr = 0;
    public float TotalMinSkinExtraSatr = 0;
    public float TotalMaxSkinExtraValue = 0;
    public float TotalMinSkinExtraValue = 0;

    [Header("Min Max Body attributes: Male")]
    public int raceSumM = 0;
    public float TotalMaxBodySizeM = 0;
    public float TotalMinBodySizeM = 0;
    public float TotalMaxTorsoLenghtM = 0;
    public float TotalMinTorsoLenghtM = 0;
    public float TotalMaxArmSizeM = 0;
    public float TotalMinArmSizeM = 0;
    public float TotalMaxShoulderWidthM = 0;
    public float TotalMinShoulderWidthM = 0;
    public float TotalMaxShoulderPoseXM = 0;
    public float TotalMinShoulderPoseXM = 0;
    public float TotalMaxChestSizeM = 0;
    public float TotalMinChestSizeM = 0;
    public float TotalMaxWaistSizeM = 0;
    public float TotalMinWaistSizeM = 0;
    public float TotalMaxHipSizeM = 0;
    public float TotalMinHipSizeM = 0;
    public float TotalMaxLegLenghtM = 0;
    public float TotalMinLegLenghtM = 0;
    public float TotalMaxHipWidthM = 0;
    public float TotalMinHipWidthM = 0;
    public float TotalMaxHipPlaceXM = 0;
    public float TotalMinHipPlaceXM = 0;
    public float TotalMaxJawSizeM = 0;
    public float TotalMinJawSizeM = 0;
    public float TotalMaxJawPlaceYM = 0;
    public float TotalMinJawPlaceYM = 0;
    public float TotalMaxSkinHueM = 0;
    public float TotalMinSkinHueM = 0;
    public float TotalMaxSkinToneM = 0;
    public float TotalMinSkinToneM = 0;
    public float TotalMaxSkinExtraSatrM = 0;
    public float TotalMinSkinExtraSatrM = 0;
    public float TotalMaxSkinExtraValueM = 0;
    public float TotalMinSkinExtraValueM = 0;

    [Header("Min Max Body attributes: Female")]
    public int raceSumF = 0;
    public float TotalMaxBodySizeF = 0;
    public float TotalMinBodySizeF = 0;
    public float TotalMaxTorsoLenghtF = 0;
    public float TotalMinTorsoLenghtF = 0;
    public float TotalMaxArmSizeF = 0;
    public float TotalMinArmSizeF = 0;
    public float TotalMaxShoulderWidthF = 0;
    public float TotalMinShoulderWidthF = 0;
    public float TotalMaxShoulderPoseXF = 0;
    public float TotalMinShoulderPoseXF = 0;
    public float TotalMaxChestSizeF = 0;
    public float TotalMinChestSizeF = 0;
    public float TotalMaxWaistSizeF = 0;
    public float TotalMinWaistSizeF = 0;
    public float TotalMaxHipSizeF = 0;
    public float TotalMinHipSizeF = 0;
    public float TotalMaxLegLenghtF = 0;
    public float TotalMinLegLenghtF = 0;
    public float TotalMaxHipWidthF = 0;
    public float TotalMinHipWidthF = 0;
    public float TotalMaxHipPlaceXF = 0;
    public float TotalMinHipPlaceXF = 0;
    public float TotalMaxJawSizeF = 0;
    public float TotalMinJawSizeF = 0;
    public float TotalMaxJawPlaceYF = 0;
    public float TotalMinJawPlaceYF = 0;
    public float TotalMaxSkinHueF = 0;
    public float TotalMinSkinHueF = 0;
    public float TotalMaxSkinToneF = 0;
    public float TotalMinSkinToneF = 0;
    public float TotalMaxSkinExtraSatrF = 0;
    public float TotalMinSkinExtraSatrF = 0;
    public float TotalMaxSkinExtraValueF = 0;
    public float TotalMinSkinExtraValueF = 0;

    public void Start()
    {
        if (BodyMinMaxSet == false)
        {
            MinMaxSetMF();
        }
        if (BodyFormed == false)
        {
            BRngSet();
        }
        else 
        {
            BForm();
        }
    }

    public void MinMaxSetMF()
    {
        //Male min max
        raceSumM = 0;
        TotalMaxBodySizeM = 0;
        TotalMinBodySizeM = 0;
        TotalMaxTorsoLenghtM = 0;
        TotalMinTorsoLenghtM = 0;
        TotalMaxArmSizeM = 0;
        TotalMinArmSizeM = 0;
        TotalMaxShoulderWidthM = 0;
        TotalMinShoulderWidthM = 0;
        TotalMaxShoulderPoseXM = 0;
        TotalMinShoulderPoseXM = 0;
        TotalMaxChestSizeM = 0;
        TotalMinChestSizeM = 0;
        TotalMaxWaistSizeM = 0;
        TotalMinWaistSizeM = 0;
        TotalMaxHipWidthM = 0;
        TotalMinHipWidthM = 0;
        TotalMaxHipSizeM = 0;
        TotalMinHipSizeM = 0;
        TotalMaxHipPlaceXM = 0;
        TotalMinHipPlaceXM = 0;
        TotalMaxLegLenghtM = 0;
        TotalMinLegLenghtM = 0;
        TotalMaxJawSizeM = 0;
        TotalMinJawSizeM = 0;
        TotalMaxJawPlaceYM = 0;
        TotalMinJawPlaceYM = 0;
        TotalMaxSkinHueM = 0;
        TotalMinSkinHueM = 0;
        TotalMaxSkinToneM = 0;
        TotalMinSkinToneM = 0;
        TotalMaxSkinExtraSatrM = 0;
        TotalMinSkinExtraSatrM = 0;
        TotalMaxSkinExtraValueM = 0;
        TotalMinSkinExtraValueM = 0;

        for (int r = 0; r < race.Length; r++)
        {
            TotalMaxBodySizeM += raceMaxBodySize[r] * race[r];
            TotalMinBodySizeM += raceMinBodySize[r] * race[r];
            TotalMaxTorsoLenghtM += raceMaxTorsoLenght[r] * race[r];
            TotalMinTorsoLenghtM += raceMinTorsoLenght[r] * race[r];
            TotalMaxArmSizeM += raceMaxArmSize[r] * race[r];
            TotalMinArmSizeM += raceMinArmSize[r] * race[r];
            TotalMaxShoulderWidthM += raceMaxShoulderWidth[r] * race[r];
            TotalMinShoulderWidthM += raceMinShoulderWidth[r] * race[r];
            TotalMaxShoulderPoseXM += raceMaxShoulderPoseX[r] * race[r];
            TotalMinShoulderPoseXM += raceMinShoulderPoseX[r] * race[r];
            TotalMaxChestSizeM += raceMaxChestSize[r] * race[r];
            TotalMinChestSizeM += raceMinChestSize[r] * race[r];
            TotalMaxWaistSizeM += raceMaxWaistSize[r] * race[r];
            TotalMinWaistSizeM += raceMinWaistSize[r] * race[r];
            TotalMaxHipWidthM += raceMaxHipWidth[r] * race[r];
            TotalMinHipWidthM += raceMinHipWidth[r] * race[r];
            TotalMaxHipSizeM += raceMaxHipSize[r] * race[r];
            TotalMinHipSizeM += raceMinHipSize[r] * race[r];
            TotalMaxHipPlaceXM += raceMaxHipPlaceX[r] * race[r];
            TotalMinHipPlaceXM += raceMinHipPlaceX[r] * race[r];
            TotalMaxLegLenghtM += raceMaxLegLenght[r] * race[r];
            TotalMinLegLenghtM += raceMinLegLenght[r] * race[r];
            TotalMaxJawSizeM += raceMaxJawSize[r] * race[r];
            TotalMinJawSizeM += raceMinJawSize[r] * race[r];
            TotalMaxJawPlaceYM += raceMaxJawPlaceY[r] * race[r];
            TotalMinJawPlaceYM += raceMinJawPlaceY[r] * race[r];
            TotalMaxSkinHueM += raceMaxSkinHue[r] * race[r];
            TotalMinSkinHueM += raceMinSkinHue[r] * race[r];
            TotalMaxSkinToneM += raceMaxSkinTone[r] * race[r];
            TotalMinSkinToneM += raceMinSkinTone[r] * race[r];
            TotalMaxSkinExtraSatrM += raceMaxSkinExtraSatr[r] * race[r];
            TotalMinSkinExtraSatrM += raceMinSkinExtraSatr[r] * race[r];
            TotalMaxSkinExtraValueM += raceMaxSkinExtraValue[r] * race[r];
            TotalMinSkinExtraValueM += raceMinSkinExtraValue[r] * race[r];
            raceSumM += race[r];
        }

        TotalMaxBodySizeM = TotalMaxBodySizeM / raceSumM;
        TotalMinBodySizeM = TotalMinBodySizeM / raceSumM;
        TotalMaxTorsoLenghtM = TotalMaxTorsoLenghtM / raceSumM;
        TotalMinTorsoLenghtM = TotalMinTorsoLenghtM / raceSumM;
        TotalMaxArmSizeM = TotalMaxArmSizeM / raceSumM;
        TotalMinArmSizeM = TotalMinArmSizeM / raceSumM;
        TotalMaxShoulderWidthM = TotalMaxShoulderWidthM / raceSumM;
        TotalMinShoulderWidthM = TotalMinShoulderWidthM / raceSumM;
        TotalMaxShoulderPoseXM = TotalMaxShoulderPoseXM / raceSumM;
        TotalMinShoulderPoseXM = TotalMinShoulderPoseXM / raceSumM;
        TotalMaxChestSizeM = TotalMaxChestSizeM / raceSumM;
        TotalMinChestSizeM = TotalMinChestSizeM / raceSumM;
        TotalMaxWaistSizeM = TotalMaxWaistSizeM / raceSumM;
        TotalMinWaistSizeM = TotalMinWaistSizeM / raceSumM;
        TotalMaxHipWidthM = TotalMaxHipWidthM / raceSumM;
        TotalMinHipWidthM = TotalMinHipWidthM / raceSumM;
        TotalMaxHipSizeM = TotalMaxHipSizeM / raceSumM;
        TotalMinHipSizeM = TotalMinHipSizeM / raceSumM;
        TotalMaxHipPlaceXM = TotalMaxHipPlaceXM / raceSumM;
        TotalMinHipPlaceXM = TotalMinHipPlaceXM / raceSumM;
        TotalMaxLegLenghtM = TotalMaxLegLenghtM / raceSumM;
        TotalMinLegLenghtM = TotalMinLegLenghtM / raceSumM;
        TotalMaxJawSizeM = TotalMaxJawSizeM / raceSumM;
        TotalMinJawSizeM = TotalMinJawSizeM / raceSumM;
        TotalMaxJawPlaceYM = TotalMaxJawPlaceYM / raceSumM;
        TotalMinJawPlaceYM = TotalMinJawPlaceYM / raceSumM;
        TotalMaxSkinHueM = TotalMaxSkinHueM / raceSumM;
        TotalMinSkinHueM = TotalMinSkinHueM / raceSumM;
        TotalMaxSkinToneM = TotalMaxSkinToneM / raceSumM;
        TotalMinSkinToneM = TotalMinSkinToneM / raceSumM;
        TotalMaxSkinExtraSatrM = TotalMaxSkinExtraSatrM / raceSumM;
        TotalMinSkinExtraSatrM = TotalMinSkinExtraSatrM / raceSumM;
        TotalMaxSkinExtraValueM = TotalMaxSkinExtraValueM / raceSumM;
        TotalMinSkinExtraValueM = TotalMinSkinExtraValueM / raceSumM;

        //Female min max
        raceSumF = 0;
        TotalMaxBodySizeF = 0;
        TotalMinBodySizeF = 0;
        TotalMaxTorsoLenghtF = 0;
        TotalMinTorsoLenghtF = 0;
        TotalMaxArmSizeF = 0;
        TotalMinArmSizeF = 0;
        TotalMaxShoulderWidthF = 0;
        TotalMinShoulderWidthF = 0;
        TotalMaxShoulderPoseXF = 0;
        TotalMinShoulderPoseXF = 0;
        TotalMaxChestSizeF = 0;
        TotalMinChestSizeF = 0;
        TotalMaxWaistSizeF = 0;
        TotalMinWaistSizeF = 0;
        TotalMaxHipWidthF = 0;
        TotalMinHipWidthF = 0;
        TotalMaxHipSizeF = 0;
        TotalMinHipSizeF = 0;
        TotalMaxHipPlaceXF = 0;
        TotalMinHipPlaceXF = 0;
        TotalMaxLegLenghtF = 0;
        TotalMinLegLenghtF = 0;
        TotalMaxJawSizeF = 0;
        TotalMinJawSizeF = 0;
        TotalMaxJawPlaceYF = 0;
        TotalMinJawPlaceYF = 0;
        TotalMaxSkinHueF = 0;
        TotalMinSkinHueF = 0;
        TotalMaxSkinToneF = 0;
        TotalMinSkinToneF = 0;
        TotalMaxSkinExtraSatrF = 0;
        TotalMinSkinExtraSatrF = 0;
        TotalMaxSkinExtraValueF = 0;
        TotalMinSkinExtraValueF = 0;

        for (int r = 0; r < race.Length; r++)
        {
            TotalMaxBodySizeF += raceMaxBodySizeF[r] * race[r];
            TotalMinBodySizeF += raceMinBodySizeF[r] * race[r];
            TotalMaxTorsoLenghtF += raceMaxTorsoLenghtF[r] * race[r];
            TotalMinTorsoLenghtF += raceMinTorsoLenghtF[r] * race[r];
            TotalMaxArmSizeF += raceMaxArmSizeF[r] * race[r];
            TotalMinArmSizeF += raceMinArmSizeF[r] * race[r];
            TotalMaxShoulderWidthF += raceMaxShoulderWidthF[r] * race[r];
            TotalMinShoulderWidthF += raceMinShoulderWidthF[r] * race[r];
            TotalMaxShoulderPoseXF += raceMaxShoulderPoseXF[r] * race[r];
            TotalMinShoulderPoseXF += raceMinShoulderPoseXF[r] * race[r];
            TotalMaxChestSizeF += raceMaxChestSizeF[r] * race[r];
            TotalMinChestSizeF += raceMinChestSizeF[r] * race[r];
            TotalMaxWaistSizeF += raceMaxWaistSizeF[r] * race[r];
            TotalMinWaistSizeF += raceMinWaistSizeF[r] * race[r];
            TotalMaxHipWidthF += raceMaxHipWidthF[r] * race[r];
            TotalMinHipWidthF += raceMinHipWidthF[r] * race[r];
            TotalMaxHipSizeF += raceMaxHipSizeF[r] * race[r];
            TotalMinHipSizeF += raceMinHipSizeF[r] * race[r];
            TotalMaxHipPlaceXF += raceMaxHipPlaceXF[r] * race[r];
            TotalMinHipPlaceXF += raceMinHipPlaceXF[r] * race[r];
            TotalMaxLegLenghtF += raceMaxLegLenghtF[r] * race[r];
            TotalMinLegLenghtF += raceMinLegLenghtF[r] * race[r];
            TotalMaxJawSizeF += raceMaxJawSizeF[r] * race[r];
            TotalMinJawSizeF += raceMinJawSizeF[r] * race[r];
            TotalMaxJawPlaceYF += raceMaxJawPlaceYF[r] * race[r];
            TotalMinJawPlaceYF += raceMinJawPlaceYF[r] * race[r];
            TotalMaxSkinHueF += raceMaxSkinHueF[r] * race[r];
            TotalMinSkinHueF += raceMinSkinHueF[r] * race[r];
            TotalMaxSkinToneF += raceMaxSkinToneF[r] * race[r];
            TotalMinSkinToneF += raceMinSkinToneF[r] * race[r];
            TotalMaxSkinExtraSatrF += raceMaxSkinExtraSatrF[r] * race[r];
            TotalMinSkinExtraSatrF += raceMinSkinExtraSatrF[r] * race[r];
            TotalMaxSkinExtraValueF += raceMaxSkinExtraValueF[r] * race[r];
            TotalMinSkinExtraValueF += raceMinSkinExtraValueF[r] * race[r];
            raceSumF += race[r];
        }

        TotalMaxBodySizeF = TotalMaxBodySizeF / raceSumF;
        TotalMinBodySizeF = TotalMinBodySizeF / raceSumF;
        TotalMaxTorsoLenghtF = TotalMaxTorsoLenghtF / raceSumF;
        TotalMinTorsoLenghtF = TotalMinTorsoLenghtF / raceSumF;
        TotalMaxArmSizeF = TotalMaxArmSizeF / raceSumF;
        TotalMinArmSizeF = TotalMinArmSizeF / raceSumF;
        TotalMaxShoulderWidthF = TotalMaxShoulderWidthF / raceSumF;
        TotalMinShoulderWidthF = TotalMinShoulderWidthF / raceSumF;
        TotalMaxShoulderPoseXF = TotalMaxShoulderPoseXF / raceSumF;
        TotalMinShoulderPoseXF = TotalMinShoulderPoseXF / raceSumF;
        TotalMaxChestSizeF = TotalMaxChestSizeF / raceSumF;
        TotalMinChestSizeF = TotalMinChestSizeF / raceSumF;
        TotalMaxWaistSizeF = TotalMaxWaistSizeF / raceSumF;
        TotalMinWaistSizeF = TotalMinWaistSizeF / raceSumF;
        TotalMaxHipWidthF = TotalMaxHipWidthF / raceSumF;
        TotalMinHipWidthF = TotalMinHipWidthF / raceSumF;
        TotalMaxHipSizeF = TotalMaxHipSizeF / raceSumF;
        TotalMinHipSizeF = TotalMinHipSizeF / raceSumF;
        TotalMaxHipPlaceXF = TotalMaxHipPlaceXF / raceSumF;
        TotalMinHipPlaceXF = TotalMinHipPlaceXF / raceSumF;
        TotalMaxLegLenghtF = TotalMaxLegLenghtF / raceSumF;
        TotalMinLegLenghtF = TotalMinLegLenghtF / raceSumF;
        TotalMaxJawSizeF = TotalMaxJawSizeF / raceSumF;
        TotalMinJawSizeF = TotalMinJawSizeF / raceSumF;
        TotalMaxJawPlaceYF = TotalMaxJawPlaceYF / raceSumF;
        TotalMinJawPlaceYF = TotalMinJawPlaceYF / raceSumF;
        TotalMaxSkinHueF = TotalMaxSkinHueF / raceSumM;
        TotalMinSkinHueF = TotalMinSkinHueF / raceSumM;
        TotalMaxSkinToneF = TotalMaxSkinToneF / raceSumM;
        TotalMinSkinToneF = TotalMinSkinToneF / raceSumM;
        TotalMaxSkinExtraSatrF = TotalMaxSkinExtraSatrF / raceSumM;
        TotalMinSkinExtraSatrF = TotalMinSkinExtraSatrF / raceSumM;
        TotalMaxSkinExtraValueF = TotalMaxSkinExtraValueF / raceSumM;
        TotalMinSkinExtraValueF = TotalMinSkinExtraValueF / raceSumM;
        MinMaxSet();
    }

    public void MinMaxSet()
    {
        TotalMaxBodySize = Mathf.Lerp(TotalMaxBodySizeM, TotalMaxBodySizeF, femininity);
        TotalMinBodySize = Mathf.Lerp(TotalMinBodySizeM, TotalMinBodySizeF, femininity);
        TotalMaxTorsoLenght = Mathf.Lerp(TotalMaxTorsoLenghtM, TotalMaxTorsoLenghtF, femininity);
        TotalMinTorsoLenght = Mathf.Lerp(TotalMinTorsoLenghtM, TotalMinTorsoLenghtF, femininity);
        TotalMaxArmSize = Mathf.Lerp(TotalMaxArmSizeM, TotalMaxArmSizeF, femininity);
        TotalMinArmSize = Mathf.Lerp(TotalMinArmSizeM, TotalMinArmSizeF, femininity);
        TotalMaxShoulderWidth = Mathf.Lerp(TotalMaxShoulderWidthM, TotalMaxShoulderWidthF, femininity);
        TotalMinShoulderWidth = Mathf.Lerp(TotalMinShoulderWidthM, TotalMinShoulderWidthF, femininity);
        TotalMaxShoulderPoseX = Mathf.Lerp(TotalMaxShoulderPoseXM, TotalMaxShoulderPoseXF, femininity);
        TotalMinShoulderPoseX = Mathf.Lerp(TotalMinShoulderPoseXM, TotalMinShoulderPoseXF, femininity);
        TotalMaxChestSize = Mathf.Lerp(TotalMaxChestSizeM, TotalMaxChestSizeF, femininity);
        TotalMinChestSize = Mathf.Lerp(TotalMinChestSizeM, TotalMinChestSizeF, femininity);
        TotalMaxWaistSize = Mathf.Lerp(TotalMaxWaistSizeM, TotalMaxWaistSizeF, femininity);
        TotalMinWaistSize = Mathf.Lerp(TotalMinWaistSizeM, TotalMinWaistSizeF, femininity);
        TotalMaxHipWidth = Mathf.Lerp(TotalMaxHipWidthM, TotalMaxHipWidthF, femininity);
        TotalMinHipWidth = Mathf.Lerp(TotalMinHipWidthM, TotalMinHipWidthF, femininity);
        TotalMaxHipSize = Mathf.Lerp(TotalMaxHipSizeM, TotalMaxHipSizeF, femininity);
        TotalMinHipSize = Mathf.Lerp(TotalMinHipSizeM, TotalMinHipSizeF, femininity);
        TotalMaxHipPlaceX = Mathf.Lerp(TotalMaxHipPlaceXM, TotalMaxHipPlaceXF, femininity);
        TotalMinHipPlaceX = Mathf.Lerp(TotalMinHipPlaceXM, TotalMinHipPlaceXF, femininity);
        TotalMaxLegLenght = Mathf.Lerp(TotalMaxLegLenghtM, TotalMaxLegLenghtF, femininity);
        TotalMinLegLenght = Mathf.Lerp(TotalMinLegLenghtM, TotalMinLegLenghtF, femininity);
        TotalMaxJawSize = Mathf.Lerp(TotalMaxJawSizeM, TotalMaxJawSizeF, femininity);
        TotalMinJawSize = Mathf.Lerp(TotalMinJawSizeM, TotalMinJawSizeF, femininity);
        TotalMaxJawPlaceY = Mathf.Lerp(TotalMaxJawPlaceYM, TotalMaxJawPlaceYF, femininity);
        TotalMinJawPlaceY = Mathf.Lerp(TotalMinJawPlaceYM, TotalMinJawPlaceYF, femininity);
        TotalMaxSkinHue = Mathf.Lerp(TotalMaxSkinHueM, TotalMaxSkinHueF, femininity);
        TotalMinSkinHue = Mathf.Lerp(TotalMinSkinHueM, TotalMinSkinHueF, femininity);
        TotalMaxSkinTone = Mathf.Lerp(TotalMaxSkinToneM, TotalMaxSkinToneF, femininity);
        TotalMinSkinTone = Mathf.Lerp(TotalMinSkinToneM, TotalMinSkinToneF, femininity);
        TotalMaxSkinExtraSatr = Mathf.Lerp(TotalMaxSkinExtraSatrM, TotalMaxSkinExtraSatrF, femininity);
        TotalMinSkinExtraSatr = Mathf.Lerp(TotalMinSkinExtraSatrM, TotalMinSkinExtraSatrF, femininity);
        TotalMaxSkinExtraValue = Mathf.Lerp(TotalMaxSkinExtraValueM, TotalMaxSkinExtraValueF, femininity);
        TotalMinSkinExtraValue = Mathf.Lerp(TotalMinSkinExtraValueM, TotalMinSkinExtraValueF, femininity);
        BodyMinMaxSet = true;
    }

    [ContextMenu("Randomize Body")]
    public void BRngSet()
    {
        //This randomly sets body proportions within the min and max body parameters
        BodySize = Random.Range(TotalMaxBodySize, TotalMinBodySize);
        JawSize = Random.Range(TotalMaxJawSize, TotalMinJawSize);
        JawPlaceY = Random.Range(TotalMaxJawPlaceY, TotalMinJawPlaceY);
        TorsoLenght = Random.Range(TotalMaxTorsoLenght, TotalMinTorsoLenght);
        ArmSize = Random.Range(TotalMaxArmSize, TotalMinArmSize);
        ShoulderWidth = Random.Range(TotalMaxShoulderWidth, TotalMinShoulderWidth);
        ShoulderPoseX = Random.Range(TotalMaxShoulderPoseX, TotalMinShoulderPoseX);
        ChestSize = Random.Range(TotalMaxChestSize, TotalMinChestSize);
        WaistSize = Random.Range(TotalMaxWaistSize, TotalMinWaistSize);
        HipSize = Random.Range(TotalMaxHipSize, TotalMinHipSize);
        LegLenght = Random.Range(TotalMaxLegLenght, TotalMinLegLenght);
        //SkinHue = Random.Range(TotalMaxSkinHue, TotalMinSkinHue);
        SkinTone = Random.Range(TotalMaxSkinTone, TotalMinSkinTone);
        //SkinExtraSatr = Random.Range(TotalMaxSkinExtraSatr, TotalMinSkinExtraSatr);
        //SkinExtraValue = Random.Range(TotalMaxSkinExtraValue, TotalMinSkinExtraValue);

        BodyFormed = true;
        BForm();
    }

    [ContextMenu("Reform Body")]
    public void BForm()
    {
        //This applys all the body proportion values to the actuall body
        this.gameObject.GetComponent<Transform>().localScale = new Vector3(BodySize, BodySize, 1f);
        Head.GetComponent<Transform>().localScale = new Vector3(HeadSize, HeadSize, 1f);

        Jaw.GetComponent<Transform>().localScale = new Vector3(1f, JawSize, 1f);
        Jaw.GetComponent<Transform>().localPosition = new Vector3(5.121778f, 0.0009115596f + JawPlaceY - ((JawSize-1f) * 4f), 0f);

        LArm[0].GetComponent<Transform>().localScale = new Vector3(ArmSize, ArmSize, 1);
        LArm[1].GetComponent<Transform>().localScale = new Vector3(ArmSize, ArmSize, 1);
        LArm[2].GetComponent<Transform>().localScale = new Vector3(ArmSize / 100f * 80f + 0.2f, ArmSize / 2f + 0.5f, 1f);
        LArm[3].GetComponent<Transform>().localScale = new Vector3(ArmSize / 100f * 80f + 0.2f, ArmSize / 2f + 0.5f, 1f);

        RArm[0].GetComponent<Transform>().localScale = new Vector3(ArmSize, ArmSize, 1f);
        RArm[1].GetComponent<Transform>().localScale = new Vector3(ArmSize, ArmSize, 1f);
        RArm[2].GetComponent<Transform>().localScale = new Vector3(ArmSize / 100f * 80f + 0.2f, ArmSize / 2f + 0.5f, 1f);
        RArm[3].GetComponent<Transform>().localScale = new Vector3(ArmSize / 100f * 80f + 0.2f, ArmSize / 2f + 0.5f, 1f);

        LArmBones[1].GetComponent<Transform>().localPosition = new Vector3(6.128047f + ShoulderWidth + ShoulderPoseX, 20.02367f, 0f);
        RArmBones[1].GetComponent<Transform>().localPosition = new Vector3(-4.747837f - ShoulderWidth + ShoulderPoseX, 20.04413f, 0f);
        LArm[0].GetComponent<Transform>().localPosition = new Vector3(4.958886f + ShoulderWidth + ShoulderPoseX, -1.310708f + (ShoulderWidth/100f * 33f) + (ShoulderPoseX / 100f * 33f), 0f);
        RArm[0].GetComponent<Transform>().localPosition = new Vector3(4.381568f + ShoulderWidth - ShoulderPoseX, 1.626502f - (ShoulderWidth / 100f * 33f) + (ShoulderPoseX / 100f * 33f), 0f);

        Chest.GetComponent<Transform>().localScale = new Vector3(1f, 1f + (ShoulderWidth * 0.075f) + ((ArmSize - 1f) * 0.2f), 1f);
        Waist.GetComponent<Transform>().localScale = new Vector3(WaistSize, WaistSize, 1f);

        LLeg[0].GetComponent<Transform>().localScale = new Vector3(HipSize, HipSize, 1f);
        LLeg[1].GetComponent<Transform>().localScale = new Vector3(HipSize, HipSize, 1f);
        LLeg[2].GetComponent<Transform>().localScale = new Vector3(HipSize / 100f * 60f + 0.4f, HipSize / 2f + 0.5f, 1f);
        LLeg[3].GetComponent<Transform>().localScale = new Vector3(HipSize / 100f * 60f + 0.4f, HipSize / 2f + 0.5f, 1f);

        RLeg[0].GetComponent<Transform>().localScale = new Vector3(HipSize, HipSize, 0f);
        RLeg[1].GetComponent<Transform>().localScale = new Vector3(HipSize, HipSize, 0f);
        RLeg[2].GetComponent<Transform>().localScale = new Vector3(HipSize / 100f * 60f + 0.4f, HipSize / 2f + 0.5f, 0f);
        RLeg[3].GetComponent<Transform>().localScale = new Vector3(HipSize / 100f * 60f + 0.4f, HipSize / 2f + 0.5f, 0f);

        LArmBones[2].GetComponent<Transform>().localPosition = new Vector3(12.31246f + TorsoLenght, 0.000207901f, 0f);
        RArmBones[2].GetComponent<Transform>().localPosition = new Vector3(12.31352f + TorsoLenght, -0.002229691f, 0f);
        LArm[2].GetComponent<Transform>().localPosition = new Vector3(12.31833f + TorsoLenght, 0f, 0f);
        RArm[2].GetComponent<Transform>().localPosition = new Vector3(12.3181f + TorsoLenght, 0f, 0f);
        LArm[4].GetComponent<Transform>().localPosition = new Vector3(6.22759f, 2.594614f - TorsoLenght, 0f);
        RArm[4].GetComponent<Transform>().localPosition = new Vector3(-4.650712f, 2.614185f - TorsoLenght, 0f);
        LHand.GetComponent<Transform>().localPosition = new Vector3(7.644968f + TorsoLenght, -6.25493f, 0f);
        RHand.GetComponent<Transform>().localPosition = new Vector3(7.780493f + TorsoLenght, 4.622524f, 0f);
        Spine[1].GetComponent<Transform>().localPosition = new Vector3(6.604286f + TorsoLenght, -1.122564f, 0f);
        Spine[2].GetComponent<Transform>().localPosition = new Vector3(2.623064f + TorsoLenght, -1.61729f, 0f);

        LLegBones[0].GetComponent<Transform>().localPosition = new Vector3(9.573837f, -1.800162f + LLegsPlaceX - HipWidth + HipPlaceX, 0f);
        RLegBones[0].GetComponent<Transform>().localPosition = new Vector3(9.483291f, 2.206104f + RLegsPlaceX + HipWidth + HipPlaceX, 0f);

        LLegBones[2].GetComponent<Transform>().localPosition = new Vector3(15.47359f + (TorsoLenght * 1.6f) + LegLenght, 0f, 0f);
        RLegBones[2].GetComponent<Transform>().localPosition = new Vector3(15.47359f + (TorsoLenght * 1.6f) + LegLenght, 0f, 0f);
        LLeg[2].GetComponent<Transform>().localPosition = new Vector3(15.47861f + (TorsoLenght * 1.6f) + LegLenght, -0.006117821f, 0f);
        RLeg[2].GetComponent<Transform>().localPosition = new Vector3(15.47861f + (TorsoLenght * 1.6f) + LegLenght, -0.006117821f, 0f);
        LLeg[4].GetComponent<Transform>().localPosition = new Vector3(3.052341f, -26.44868f - (TorsoLenght * 1.6f) - LegLenght, 0f);
        RLeg[4].GetComponent<Transform>().localPosition = new Vector3(-2.906408f, -26.44456f - (TorsoLenght * 1.6f) - LegLenght, 0f);
        LFoot.GetComponent<Transform>().localPosition = new Vector3(18.62f + (TorsoLenght * 1.6f) + LegLenght, -1.65f, 0f);
        RFoot.GetComponent<Transform>().localPosition = new Vector3(18.62f + (TorsoLenght * 1.6f) + LegLenght, -1.65f, 0f);
        Spine[0].GetComponent<Transform>().localPosition = new Vector3(0.2537366f, -4.806909f + ((TorsoLenght * 2f) * 1.6f) + (LegLenght * 2f), 0f);
        BFColor();
    }

    public void BFColor()
    {
        float satr = ((SkinTone*0.8f) + SkinExtraSatr) /100;
        if (satr > 1) { satr = 1; }else if(satr < 0) { satr = 0; }
        skinColor = Color.HSVToRGB(SkinHue/360, satr, 1f - SkinTone/100);
        float value = (SkinTone + SkinExtraValue) / 100;
        if (value > 1) { value = 1; } else if (value < 0) { value = 0; }
        skinColor = Color.HSVToRGB(SkinHue / 360, satr, 1f - value);

        for (int i = 0; i < skinParts.Count(); i++) 
        { 
            skinParts[i].GetComponent<SpriteRenderer>().color = skinColor; 
        }
    }
}
