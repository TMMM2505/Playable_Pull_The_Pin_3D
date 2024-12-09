package io.odeeo.sdk;

import android.util.Log;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonSerializationContext;
import com.google.gson.JsonSerializer;
import com.google.gson.JsonPrimitive;
import java.lang.reflect.Type;

import io.odeeo.sdk.callbackData.ImpressionData;
import io.odeeo.sdk.callbackData.AdData;
import io.odeeo.sdk.AdUnit.PlacementType;
import io.odeeo.sdk.common.SdkInitializationListener;
import com.unity3d.player.UnityPlayer;

public class OdeeoAndroidHelper
{
    public void initialize(String unityVersion, String SdkVersion, SdkInitializationListener listener, String appKey)
    {
        UnityPlayer.currentActivity.runOnUiThread(new Runnable()
        {
            @Override
            public void run() {
                OdeeoSDK.INSTANCE.setEngineInformation("unity_" + unityVersion, SdkVersion);
                OdeeoSDK.INSTANCE.setOnInitializationListener(listener);
                try
                {
                    OdeeoSDK.INSTANCE.initialize(UnityPlayer.currentActivity, appKey);
                }
                catch(Exception e)
                {
                    Log.e("Unity Bridge", "Initialization Failed");
                }
            }
        });
    }
    
    public String impressionDataString(ImpressionData data)
    {
        Gson gson = new GsonBuilder()
            .registerTypeAdapter(PlacementType.class, new JsonSerializer<PlacementType>() {
                @Override
                public JsonElement serialize(PlacementType src, Type typeOfSrc, JsonSerializationContext context) {
                    return new JsonPrimitive(src.ordinal());
                }
            })
            .create();
        
        String str = gson.toJson(data);
        return str;
    }
    
    public String adDataString(AdData data)
    {
        Gson gson = new GsonBuilder()
            .registerTypeAdapter(PlacementType.class, new JsonSerializer<PlacementType>() {
                @Override
                public JsonElement serialize(PlacementType src, Type typeOfSrc, JsonSerializationContext context) {
                    return new JsonPrimitive(src.ordinal());
                }
            })
            .create();
                    
        String str = gson.toJson(data);
        return str;
    }
}