using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeProfileChanger : MonoBehaviour
{

    public float warpIntensity = 1;


    public Volume volume;
    
    
    LensDistortion lens;
    ChromaticAberration chrom;
    DepthOfField dof;
    ColorAdjustments col;


    void Start(){

        volume.profile.TryGet<LensDistortion>(out lens);
        volume.profile.TryGet<ChromaticAberration>(out chrom);
        volume.profile.TryGet<DepthOfField>(out dof);
        volume.profile.TryGet<ColorAdjustments>(out col);

        print(lens.intensity);

        // fog.enabled.overrideState = overrideFog;
        // fog.enabled.value = enableFog;
        StartCoroutine(Warping());
    }

    public IEnumerator Warping(){

        volume.enabled = true;
        while(col.postExposure.value < 3)
        {
            volume.weight += Time.deltaTime;
            col.postExposure.value += Time.deltaTime*3; // this happens in a second
            //col.saturation.value += Time.deltaTime*100;
            yield return null;
        }
        while(col.postExposure.value > 0)
        {
            col.postExposure.value -= Time.deltaTime*4;
            yield return null;
        }
        col.postExposure.value = 0;

        // in the pill effect
        float timer = 1;
        warpIntensity = 1;
        while(warpIntensity > .01f){

            lens.intensity.value = Mathf.Lerp(lens.intensity.value ,PingPong(.5f*warpIntensity,-.5f*warpIntensity,.1f*warpIntensity), .005f);
            lens.scale.value = Mathf.Lerp(lens.scale.value ,PingPong(2,.9f,.2f*warpIntensity), .01f);

            chrom.intensity.value = PingPong(1,.2f,2*warpIntensity);

            dof.focusDistance.value = PingPong(5,3,1f*warpIntensity);

            timer -= Time.deltaTime/30; // divide by 60 to make it one minute long
            yield return null;
        }

        while(volume.weight > 0){
            volume.weight -= Time.deltaTime;
            yield return null;
        }

        // pill effect has now work off


    }
    public float PingPong(float max,float min,float speed = 1)
    {
        return  (Mathf.PingPong(Time.time*speed, 1)*(max-min)) + min;
    }

}
