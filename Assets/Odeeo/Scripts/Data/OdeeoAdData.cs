using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Odeeo.Data
{
    public class OdeeoAdData
    {
        private string _sessionID;
        private OdeeoSdk.PlacementType _placementType;
        private string _placementID;
        private string _country;
        private double _eCPM;
        private string _transactionID;
        private string _customTag;

#if UNITY_ANDROID && !UNITY_EDITOR
    public OdeeoAdData(AndroidJavaObject ptr)
    {
        if (ptr == null)
        {
            OdeeoSdk.LogE( OdeeoSdk.LogLevel.Info, "OdeeoAdData is NULL");
            return;
        }

        string dataString;
        using (AndroidJavaObject helper = new AndroidJavaObject(OdeeoSdk.ANDROID_HELPER)) 
            dataString = helper.Call<string>("adDataString", ptr);

        ParseJsonString(dataString);
    }
#elif UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string _odeeoSdkAdDataGetString(IntPtr obj);
    [DllImport("__Internal")]
    private static extern void _odeeoSdkDestroyBridgeReference(IntPtr obj);

    public OdeeoAdData(IntPtr ptr)
    {
        string dataString = _odeeoSdkAdDataGetString(ptr);
        ParseJsonString(dataString);

        _odeeoSdkDestroyBridgeReference(ptr);
    }
#endif

#if UNITY_EDITOR
        public OdeeoAdData(OdeeoSdk.PlacementType type, string customTag)
        {
            _sessionID = "test_editor";
            _placementType = type;
            _placementID = "test_editor";
            _country = "test_editor";
            _eCPM = 0d;
            _transactionID = "test_editor";
            _customTag = customTag;
        }
#endif

        private void ParseJsonString(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
                return;

            AdDataJson data = JsonUtility.FromJson<AdDataJson>(jsonString);

            _sessionID = data.sessionID;
            _placementType = (OdeeoSdk.PlacementType)data.placementType;
            _placementID = data.placementID;
            _country = data.country;
            _eCPM = data.eCPM;
            _transactionID = data.transactionID;
            _customTag = data.customTag;
        }
        
        public string GetSessionID()
        {
            return _sessionID;
        }

        public OdeeoSdk.PlacementType GetPlacementType()
        {
            return _placementType;
        }

        public string GetPlacementID()
        {
            return _placementID;
        }

        public string GetCountry()
        {
            return _country;
        }

        public double GetEcpm()
        {
            return _eCPM;
        }

        public string GetTransactionID()
        {
            return _transactionID;
        }
        
        public string GetCustomTag()
        {
            return _customTag;
        }

        [Serializable]
        private class AdDataJson
        {
            public string sessionID;
            public int placementType;
            public string placementID;
            public string country;
            public double eCPM;
            public string transactionID;
            public string customTag;
        }
    }
}
