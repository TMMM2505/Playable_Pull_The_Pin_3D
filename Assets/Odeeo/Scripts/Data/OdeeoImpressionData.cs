using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Odeeo.Data
{
    public class OdeeoImpressionData
    {
        private string _sessionID = Guid.Empty.ToString();
        private OdeeoSdk.PlacementType _placementType = OdeeoSdk.PlacementType.AudioIconAd;
        private string _placementID = Guid.Empty.ToString();
        private string _country = "";
        private double _payableAmount = 0;
        private string _transactionID = "";
        private string _customTag = "";

#if UNITY_ANDROID && !UNITY_EDITOR
    public OdeeoImpressionData(AndroidJavaObject ptr)
    {
        string dataString;
        using (AndroidJavaObject helper = new AndroidJavaObject(OdeeoSdk.ANDROID_HELPER)) 
            dataString = helper.Call<string>("impressionDataString", ptr);

        ParseJsonString(dataString);
    }
#elif UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern string _odeeoSdkImpressionDataGetString(IntPtr obj);
    
    [DllImport("__Internal")]
    private static extern void _odeeoSdkDestroyBridgeReference(IntPtr obj);

    public OdeeoImpressionData(IntPtr ptr)
    {
        string dataString = _odeeoSdkImpressionDataGetString(ptr);
        ParseJsonString(dataString);
        
        _odeeoSdkDestroyBridgeReference(ptr);
    }
#endif

#if UNITY_EDITOR
        public OdeeoImpressionData(OdeeoSdk.PlacementType type, string customTag)
        {
            _sessionID = "test_editor";
            _placementType = type;
            _placementID = "test_editor";
            _country = "test_editor";
            _payableAmount = 0d;
            _transactionID = "test_editor";
            _customTag = customTag;
        }
#endif
        private void ParseJsonString(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
                return;

            ImpressionDataJson data = JsonUtility.FromJson<ImpressionDataJson>(jsonString);

            _sessionID = data.sessionID;
            _placementType = (OdeeoSdk.PlacementType)data.placementType;
            _placementID = data.placementID;
            _country = data.country;
            _payableAmount = data.payableAmount;
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

        public double GetPayableAmount()
        {
            return _payableAmount;
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
        private class ImpressionDataJson
        {
            public string sessionID;
            public int placementType;
            public string placementID;
            public string country;
            public double payableAmount;
            public string transactionID;
            public string customTag;
        }
    }
}