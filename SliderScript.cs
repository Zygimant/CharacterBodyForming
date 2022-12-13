using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public GameObject chrCrtPan;
    public int trackedBodyID = 0;
    public int WhichAspect;
    private bool targetSet = false;
    private bool minMaxSet = false;

    public Slider ThisSlider;
    public TextMeshProUGUI SlValText;
    public TextMeshProUGUI SlNameText;

    private string valRounding = "0.00";

    void Update()
    {
        if (chrCrtPan.GetComponent<ChCreatPanelScr>().BodyDiffID != trackedBodyID && chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh != null)
        {
            trackedBodyID = chrCrtPan.GetComponent<ChCreatPanelScr>().BodyDiffID;
            SetSliderValues();
            if (targetSet == false)
            {
                SetBodyValues();
                targetSet = true;
            }
        }
    }

    void Start()
    {
        chrCrtPan = GameObject.Find("Ch Creation Panel");
        SetSliderNames();
        if (chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh != null)
        {
            SetSliderValues();
            SetBodyValues();
            targetSet = true;
        }
    }

    void SetSliderNames()
    {
        switch (WhichAspect)
        {
            case 0:
                this.gameObject.name = "Body Size Slider";
                SlNameText.text = "Body Size";
                valRounding = "0.00";
                break;
            case 1:
                this.gameObject.name = "ArmSize Slider";
                SlNameText.text = "Arm Size";
                valRounding = "0.00";
                break;
            case 2:
                this.gameObject.name = "ShoulderPoseX Slider";
                SlNameText.text = "Shoulder PoseX";
                valRounding = "0.00";
                break;
            case 3:
                this.gameObject.name = "WaistSize Slider";
                SlNameText.text = "Waist Size";
                valRounding = "0.00";
                break;
            case 4:
                this.gameObject.name = "HipSize Slider";
                SlNameText.text = "Hip Size";
                valRounding = "0.00";
                break;
            case 5:
                this.gameObject.name = "LegLenght Slider";
                SlNameText.text = "Leg Lenght";
                valRounding = "0.00";
                break;
            case 6:
                this.gameObject.name = "TorsoLenght Slider";
                SlNameText.text = "Torso Lenght";
                valRounding = "0.00";
                break;
            case 7:
                this.gameObject.name = "ShoulderWidth Slider";
                SlNameText.text = "Shoulder Width";
                valRounding = "0.00";
                break;
            case 8:
                this.gameObject.name = "HipWidth Slider";
                SlNameText.text = "Hip Width";
                valRounding = "0.00";
                break;
            case 9:
                this.gameObject.name = "JawSize Slider";
                SlNameText.text = "Jaw Pointynes";
                valRounding = "0.00";
                break;
            case 10:
                this.gameObject.name = "JawPlaceY Slider";
                SlNameText.text = "Jaw Size";
                valRounding = "0.00";
                break;
            case 11:
                this.gameObject.name = "HipPlaceX Slider";
                SlNameText.text = "Hip Push Back";
                valRounding = "0.00";
                break;
            case 12:
                this.gameObject.name = "SkinHue Slider";
                SlNameText.text = "Skin Hue";
                valRounding = "0.0";
                break;
            case 13:
                this.gameObject.name = "SkinTone Slider";
                SlNameText.text = "Skin Tone";
                valRounding = "0.0";
                break;
            case 14:
                this.gameObject.name = "SkinExtraSatr Slider";
                SlNameText.text = "Skin Extra Satr";
                valRounding = "0.0";
                break;
            case 15:
                this.gameObject.name = "SkinExtraValue Slider";
                SlNameText.text = "Skin Extra Value";
                valRounding = "0.0";
                break;
        }
    }

    //This sets what the slider is set to and its min max values, based on the values of the body it's targeting
    void SetSliderValues()
    {
        minMaxSet = false;
        switch (WhichAspect)
        {
            case 0:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinBodySize;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxBodySize;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BodySize;
                break;
            case 1:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinArmSize;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxArmSize;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().ArmSize;
                break;
            case 2:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinShoulderPoseX;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxShoulderPoseX;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().ShoulderPoseX;
                break;
            case 3:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinWaistSize;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxWaistSize;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().WaistSize;
                break;
            case 4:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinHipSize;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxHipSize;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().HipSize;
                break;
            case 5:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinLegLenght;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxLegLenght;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().LegLenght;
                break;
            case 6:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinTorsoLenght;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxTorsoLenght;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TorsoLenght;
                break;
            case 7:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinShoulderWidth;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxShoulderWidth;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().ShoulderWidth;
                break;
            case 8:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinHipWidth;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxHipWidth;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().HipWidth;
                break;
            case 9:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinJawSize;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxJawSize;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().JawSize;
                break;
            case 10:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinJawPlaceY;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxJawPlaceY;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().JawPlaceY;
                break;
            case 11:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinHipPlaceX;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxHipPlaceX;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().HipPlaceX;
                break;
            case 12:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinSkinHue;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxSkinHue;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinHue;
                break;
            case 13:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinSkinTone;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxSkinTone;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinTone;
                break;
            case 14:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinSkinExtraSatr;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxSkinExtraSatr;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinExtraSatr;
                break;
            case 15:
                ThisSlider.minValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMinSkinExtraValue;
                ThisSlider.maxValue = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TotalMaxSkinExtraValue;
                ThisSlider.value = chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinExtraValue;
                break;
        }
        minMaxSet = true;
    }

    //This sets the targeted bodys value based on the changes to the sliders value and calls for the body to form
    void SetBodyValues()
    {
        SlValText.text = ThisSlider.value.ToString(valRounding);
        ThisSlider.onValueChanged.AddListener((v) =>
        {
            SlValText.text = v.ToString(valRounding);
            if (minMaxSet == true)
            {
                switch (WhichAspect)
                {
                    case 0:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BodySize = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 1:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().ArmSize = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 2:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().ShoulderPoseX = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 3:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().WaistSize = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 4:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().HipSize = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 5:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().LegLenght = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 6:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().TorsoLenght = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 7:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().ShoulderWidth = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 8:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().HipWidth = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 9:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().JawSize = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 10:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().JawPlaceY = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 11:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().HipPlaceX = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 12:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinHue = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 13:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinTone = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 14:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinExtraSatr = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                    case 15:
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().SkinExtraValue = v;
                        chrCrtPan.GetComponent<ChCreatPanelScr>().TargetCh.GetComponent<BodyForm>().BForm();
                        break;
                }
            }
        });
    }
}