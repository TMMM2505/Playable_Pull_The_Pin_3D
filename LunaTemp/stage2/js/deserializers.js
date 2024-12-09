var Deserializers = {}
Deserializers["UnityEngine.JointSpring"] = function (request, data, root) {
  var i1148 = root || request.c( 'UnityEngine.JointSpring' )
  var i1149 = data
  i1148.spring = i1149[0]
  i1148.damper = i1149[1]
  i1148.targetPosition = i1149[2]
  return i1148
}

Deserializers["UnityEngine.JointMotor"] = function (request, data, root) {
  var i1150 = root || request.c( 'UnityEngine.JointMotor' )
  var i1151 = data
  i1150.m_TargetVelocity = i1151[0]
  i1150.m_Force = i1151[1]
  i1150.m_FreeSpin = i1151[2]
  return i1150
}

Deserializers["UnityEngine.JointLimits"] = function (request, data, root) {
  var i1152 = root || request.c( 'UnityEngine.JointLimits' )
  var i1153 = data
  i1152.m_Min = i1153[0]
  i1152.m_Max = i1153[1]
  i1152.m_Bounciness = i1153[2]
  i1152.m_BounceMinVelocity = i1153[3]
  i1152.m_ContactDistance = i1153[4]
  i1152.minBounce = i1153[5]
  i1152.maxBounce = i1153[6]
  return i1152
}

Deserializers["UnityEngine.JointDrive"] = function (request, data, root) {
  var i1154 = root || request.c( 'UnityEngine.JointDrive' )
  var i1155 = data
  i1154.m_PositionSpring = i1155[0]
  i1154.m_PositionDamper = i1155[1]
  i1154.m_MaximumForce = i1155[2]
  i1154.m_UseAcceleration = i1155[3]
  return i1154
}

Deserializers["UnityEngine.SoftJointLimitSpring"] = function (request, data, root) {
  var i1156 = root || request.c( 'UnityEngine.SoftJointLimitSpring' )
  var i1157 = data
  i1156.m_Spring = i1157[0]
  i1156.m_Damper = i1157[1]
  return i1156
}

Deserializers["UnityEngine.SoftJointLimit"] = function (request, data, root) {
  var i1158 = root || request.c( 'UnityEngine.SoftJointLimit' )
  var i1159 = data
  i1158.m_Limit = i1159[0]
  i1158.m_Bounciness = i1159[1]
  i1158.m_ContactDistance = i1159[2]
  return i1158
}

Deserializers["UnityEngine.WheelFrictionCurve"] = function (request, data, root) {
  var i1160 = root || request.c( 'UnityEngine.WheelFrictionCurve' )
  var i1161 = data
  i1160.m_ExtremumSlip = i1161[0]
  i1160.m_ExtremumValue = i1161[1]
  i1160.m_AsymptoteSlip = i1161[2]
  i1160.m_AsymptoteValue = i1161[3]
  i1160.m_Stiffness = i1161[4]
  return i1160
}

Deserializers["UnityEngine.JointAngleLimits2D"] = function (request, data, root) {
  var i1162 = root || request.c( 'UnityEngine.JointAngleLimits2D' )
  var i1163 = data
  i1162.m_LowerAngle = i1163[0]
  i1162.m_UpperAngle = i1163[1]
  return i1162
}

Deserializers["UnityEngine.JointMotor2D"] = function (request, data, root) {
  var i1164 = root || request.c( 'UnityEngine.JointMotor2D' )
  var i1165 = data
  i1164.m_MotorSpeed = i1165[0]
  i1164.m_MaximumMotorTorque = i1165[1]
  return i1164
}

Deserializers["UnityEngine.JointSuspension2D"] = function (request, data, root) {
  var i1166 = root || request.c( 'UnityEngine.JointSuspension2D' )
  var i1167 = data
  i1166.m_DampingRatio = i1167[0]
  i1166.m_Frequency = i1167[1]
  i1166.m_Angle = i1167[2]
  return i1166
}

Deserializers["UnityEngine.JointTranslationLimits2D"] = function (request, data, root) {
  var i1168 = root || request.c( 'UnityEngine.JointTranslationLimits2D' )
  var i1169 = data
  i1168.m_LowerTranslation = i1169[0]
  i1168.m_UpperTranslation = i1169[1]
  return i1168
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material"] = function (request, data, root) {
  var i1170 = root || new pc.UnityMaterial()
  var i1171 = data
  i1170.name = i1171[0]
  request.r(i1171[1], i1171[2], 0, i1170, 'shader')
  i1170.renderQueue = i1171[3]
  i1170.enableInstancing = !!i1171[4]
  var i1173 = i1171[5]
  var i1172 = []
  for(var i = 0; i < i1173.length; i += 1) {
    i1172.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter', i1173[i + 0]) );
  }
  i1170.floatParameters = i1172
  var i1175 = i1171[6]
  var i1174 = []
  for(var i = 0; i < i1175.length; i += 1) {
    i1174.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter', i1175[i + 0]) );
  }
  i1170.colorParameters = i1174
  var i1177 = i1171[7]
  var i1176 = []
  for(var i = 0; i < i1177.length; i += 1) {
    i1176.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter', i1177[i + 0]) );
  }
  i1170.vectorParameters = i1176
  var i1179 = i1171[8]
  var i1178 = []
  for(var i = 0; i < i1179.length; i += 1) {
    i1178.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter', i1179[i + 0]) );
  }
  i1170.textureParameters = i1178
  var i1181 = i1171[9]
  var i1180 = []
  for(var i = 0; i < i1181.length; i += 1) {
    i1180.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag', i1181[i + 0]) );
  }
  i1170.materialFlags = i1180
  return i1170
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter"] = function (request, data, root) {
  var i1184 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter' )
  var i1185 = data
  i1184.name = i1185[0]
  i1184.value = i1185[1]
  return i1184
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter"] = function (request, data, root) {
  var i1188 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter' )
  var i1189 = data
  i1188.name = i1189[0]
  i1188.value = new pc.Color(i1189[1], i1189[2], i1189[3], i1189[4])
  return i1188
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter"] = function (request, data, root) {
  var i1192 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter' )
  var i1193 = data
  i1192.name = i1193[0]
  i1192.value = new pc.Vec4( i1193[1], i1193[2], i1193[3], i1193[4] )
  return i1192
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter"] = function (request, data, root) {
  var i1196 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter' )
  var i1197 = data
  i1196.name = i1197[0]
  request.r(i1197[1], i1197[2], 0, i1196, 'value')
  return i1196
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag"] = function (request, data, root) {
  var i1200 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag' )
  var i1201 = data
  i1200.name = i1201[0]
  i1200.enabled = !!i1201[1]
  return i1200
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Texture2D"] = function (request, data, root) {
  var i1202 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Texture2D' )
  var i1203 = data
  i1202.name = i1203[0]
  i1202.width = i1203[1]
  i1202.height = i1203[2]
  i1202.mipmapCount = i1203[3]
  i1202.anisoLevel = i1203[4]
  i1202.filterMode = i1203[5]
  i1202.hdr = !!i1203[6]
  i1202.format = i1203[7]
  i1202.wrapMode = i1203[8]
  i1202.alphaIsTransparency = !!i1203[9]
  i1202.alphaSource = i1203[10]
  i1202.graphicsFormat = i1203[11]
  i1202.sRGBTexture = !!i1203[12]
  i1202.desiredColorSpace = i1203[13]
  i1202.wrapU = i1203[14]
  i1202.wrapV = i1203[15]
  return i1202
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Cubemap"] = function (request, data, root) {
  var i1204 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Cubemap' )
  var i1205 = data
  i1204.name = i1205[0]
  i1204.atlasId = i1205[1]
  i1204.mipmapCount = i1205[2]
  i1204.hdr = !!i1205[3]
  i1204.size = i1205[4]
  i1204.anisoLevel = i1205[5]
  i1204.filterMode = i1205[6]
  var i1207 = i1205[7]
  var i1206 = []
  for(var i = 0; i < i1207.length; i += 4) {
    i1206.push( UnityEngine.Rect.MinMaxRect(i1207[i + 0], i1207[i + 1], i1207[i + 2], i1207[i + 3]) );
  }
  i1204.rects = i1206
  i1204.wrapU = i1205[8]
  i1204.wrapV = i1205[9]
  return i1204
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.Scene"] = function (request, data, root) {
  var i1210 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.Scene' )
  var i1211 = data
  i1210.name = i1211[0]
  i1210.index = i1211[1]
  i1210.startup = !!i1211[2]
  return i1210
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Transform"] = function (request, data, root) {
  var i1212 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Transform' )
  var i1213 = data
  i1212.position = new pc.Vec3( i1213[0], i1213[1], i1213[2] )
  i1212.scale = new pc.Vec3( i1213[3], i1213[4], i1213[5] )
  i1212.rotation = new pc.Quat(i1213[6], i1213[7], i1213[8], i1213[9])
  return i1212
}

Deserializers["Luna.Unity.DTO.UnityEngine.Scene.GameObject"] = function (request, data, root) {
  var i1214 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Scene.GameObject' )
  var i1215 = data
  i1214.name = i1215[0]
  i1214.tagId = i1215[1]
  i1214.enabled = !!i1215[2]
  i1214.isStatic = !!i1215[3]
  i1214.layer = i1215[4]
  return i1214
}

Deserializers["ChallengeController"] = function (request, data, root) {
  var i1216 = root || request.c( 'ChallengeController' )
  var i1217 = data
  return i1216
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings"] = function (request, data, root) {
  var i1218 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings' )
  var i1219 = data
  i1218.ambientIntensity = i1219[0]
  i1218.reflectionIntensity = i1219[1]
  i1218.ambientMode = i1219[2]
  i1218.ambientLight = new pc.Color(i1219[3], i1219[4], i1219[5], i1219[6])
  i1218.ambientSkyColor = new pc.Color(i1219[7], i1219[8], i1219[9], i1219[10])
  i1218.ambientGroundColor = new pc.Color(i1219[11], i1219[12], i1219[13], i1219[14])
  i1218.ambientEquatorColor = new pc.Color(i1219[15], i1219[16], i1219[17], i1219[18])
  i1218.fogColor = new pc.Color(i1219[19], i1219[20], i1219[21], i1219[22])
  i1218.fogEndDistance = i1219[23]
  i1218.fogStartDistance = i1219[24]
  i1218.fogDensity = i1219[25]
  i1218.fog = !!i1219[26]
  request.r(i1219[27], i1219[28], 0, i1218, 'skybox')
  i1218.fogMode = i1219[29]
  var i1221 = i1219[30]
  var i1220 = []
  for(var i = 0; i < i1221.length; i += 1) {
    i1220.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap', i1221[i + 0]) );
  }
  i1218.lightmaps = i1220
  i1218.lightProbes = request.d('Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes', i1219[31], i1218.lightProbes)
  i1218.lightmapsMode = i1219[32]
  i1218.mixedBakeMode = i1219[33]
  i1218.environmentLightingMode = i1219[34]
  i1218.ambientProbe = new pc.SphericalHarmonicsL2(i1219[35])
  i1218.referenceAmbientProbe = new pc.SphericalHarmonicsL2(i1219[36])
  i1218.useReferenceAmbientProbe = !!i1219[37]
  request.r(i1219[38], i1219[39], 0, i1218, 'customReflection')
  request.r(i1219[40], i1219[41], 0, i1218, 'defaultReflection')
  i1218.defaultReflectionMode = i1219[42]
  i1218.defaultReflectionResolution = i1219[43]
  i1218.sunLightObjectId = i1219[44]
  i1218.pixelLightCount = i1219[45]
  i1218.defaultReflectionHDR = !!i1219[46]
  i1218.hasLightDataAsset = !!i1219[47]
  i1218.hasManualGenerate = !!i1219[48]
  return i1218
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap"] = function (request, data, root) {
  var i1224 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap' )
  var i1225 = data
  request.r(i1225[0], i1225[1], 0, i1224, 'lightmapColor')
  request.r(i1225[2], i1225[3], 0, i1224, 'lightmapDirection')
  return i1224
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes"] = function (request, data, root) {
  var i1226 = root || new UnityEngine.LightProbes()
  var i1227 = data
  return i1226
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.RectTransform"] = function (request, data, root) {
  var i1234 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.RectTransform' )
  var i1235 = data
  i1234.pivot = new pc.Vec2( i1235[0], i1235[1] )
  i1234.anchorMin = new pc.Vec2( i1235[2], i1235[3] )
  i1234.anchorMax = new pc.Vec2( i1235[4], i1235[5] )
  i1234.sizeDelta = new pc.Vec2( i1235[6], i1235[7] )
  i1234.anchoredPosition3D = new pc.Vec3( i1235[8], i1235[9], i1235[10] )
  i1234.rotation = new pc.Quat(i1235[11], i1235[12], i1235[13], i1235[14])
  i1234.scale = new pc.Vec3( i1235[15], i1235[16], i1235[17] )
  return i1234
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Canvas"] = function (request, data, root) {
  var i1236 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Canvas' )
  var i1237 = data
  i1236.enabled = !!i1237[0]
  i1236.planeDistance = i1237[1]
  i1236.referencePixelsPerUnit = i1237[2]
  i1236.isFallbackOverlay = !!i1237[3]
  i1236.renderMode = i1237[4]
  i1236.renderOrder = i1237[5]
  i1236.sortingLayerName = i1237[6]
  i1236.sortingOrder = i1237[7]
  i1236.scaleFactor = i1237[8]
  request.r(i1237[9], i1237[10], 0, i1236, 'worldCamera')
  i1236.overrideSorting = !!i1237[11]
  i1236.pixelPerfect = !!i1237[12]
  i1236.targetDisplay = i1237[13]
  i1236.overridePixelPerfect = !!i1237[14]
  return i1236
}

Deserializers["UnityEngine.UI.GraphicRaycaster"] = function (request, data, root) {
  var i1238 = root || request.c( 'UnityEngine.UI.GraphicRaycaster' )
  var i1239 = data
  i1238.m_IgnoreReversedGraphics = !!i1239[0]
  i1238.m_BlockingObjects = i1239[1]
  i1238.m_BlockingMask = UnityEngine.LayerMask.FromIntegerValue( i1239[2] )
  return i1238
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasGroup"] = function (request, data, root) {
  var i1240 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasGroup' )
  var i1241 = data
  i1240.m_Alpha = i1241[0]
  i1240.m_Interactable = !!i1241[1]
  i1240.m_BlocksRaycasts = !!i1241[2]
  i1240.m_IgnoreParentGroups = !!i1241[3]
  i1240.enabled = !!i1241[4]
  return i1240
}

Deserializers["PopupBackground"] = function (request, data, root) {
  var i1242 = root || request.c( 'PopupBackground' )
  var i1243 = data
  i1242.useAnimation = !!i1243[0]
  request.r(i1243[1], i1243[2], 0, i1242, 'Background')
  i1242.ShowAnimationType = i1243[3]
  i1242.UseHideAnimation = !!i1243[4]
  i1242.HideAnimationType = i1243[5]
  return i1242
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer"] = function (request, data, root) {
  var i1244 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer' )
  var i1245 = data
  i1244.cullTransparentMesh = !!i1245[0]
  return i1244
}

Deserializers["UnityEngine.UI.Image"] = function (request, data, root) {
  var i1246 = root || request.c( 'UnityEngine.UI.Image' )
  var i1247 = data
  request.r(i1247[0], i1247[1], 0, i1246, 'm_Sprite')
  i1246.m_Type = i1247[2]
  i1246.m_PreserveAspect = !!i1247[3]
  i1246.m_FillCenter = !!i1247[4]
  i1246.m_FillMethod = i1247[5]
  i1246.m_FillAmount = i1247[6]
  i1246.m_FillClockwise = !!i1247[7]
  i1246.m_FillOrigin = i1247[8]
  i1246.m_UseSpriteMesh = !!i1247[9]
  i1246.m_PixelsPerUnitMultiplier = i1247[10]
  request.r(i1247[11], i1247[12], 0, i1246, 'm_Material')
  i1246.m_Maskable = !!i1247[13]
  i1246.m_Color = new pc.Color(i1247[14], i1247[15], i1247[16], i1247[17])
  i1246.m_RaycastTarget = !!i1247[18]
  i1246.m_RaycastPadding = new pc.Vec4( i1247[19], i1247[20], i1247[21], i1247[22] )
  return i1246
}

Deserializers["PopupChallenge"] = function (request, data, root) {
  var i1248 = root || request.c( 'PopupChallenge' )
  var i1249 = data
  i1248.useAnimation = !!i1249[0]
  request.r(i1249[1], i1249[2], 0, i1248, 'Background')
  i1248.ShowAnimationType = i1249[3]
  i1248.UseHideAnimation = !!i1249[4]
  i1248.HideAnimationType = i1249[5]
  request.r(i1249[6], i1249[7], 0, i1248, 'challengeConfig')
  i1248.currentPage = i1249[8]
  request.r(i1249[9], i1249[10], 0, i1248, 'levelChallengeItemPrefab')
  request.r(i1249[11], i1249[12], 0, i1248, 'multipleChallengeItemPrefab')
  i1248.levelChallenge = request.d('LevelChallengeContent', i1249[13], i1248.levelChallenge)
  i1248.multiplyChallenge = request.d('MultiplyChallengeContent', i1249[14], i1248.multiplyChallenge)
  request.r(i1249[15], i1249[16], 0, i1248, 'lockMultiply')
  return i1248
}

Deserializers["LevelChallengeContent"] = function (request, data, root) {
  var i1250 = root || request.c( 'LevelChallengeContent' )
  var i1251 = data
  request.r(i1251[0], i1251[1], 0, i1250, 'selectedBtn')
  request.r(i1251[2], i1251[3], 0, i1250, 'notSelectedBtn')
  request.r(i1251[4], i1251[5], 0, i1250, 'challengeFrame')
  request.r(i1251[6], i1251[7], 0, i1250, 'challengeContent')
  var i1253 = i1251[8]
  var i1252 = new (System.Collections.Generic.List$1(Bridge.ns('LevelChallengeItem')))
  for(var i = 0; i < i1253.length; i += 2) {
  request.r(i1253[i + 0], i1253[i + 1], 1, i1252, '')
  }
  i1250.levelChallengeItemList = i1252
  return i1250
}

Deserializers["MultiplyChallengeContent"] = function (request, data, root) {
  var i1256 = root || request.c( 'MultiplyChallengeContent' )
  var i1257 = data
  request.r(i1257[0], i1257[1], 0, i1256, 'selectedBtn')
  request.r(i1257[2], i1257[3], 0, i1256, 'notSelectedBtn')
  request.r(i1257[4], i1257[5], 0, i1256, 'challengeFrame')
  request.r(i1257[6], i1257[7], 0, i1256, 'challengeContent')
  var i1259 = i1257[8]
  var i1258 = new (System.Collections.Generic.List$1(Bridge.ns('MultipleChallengeItem')))
  for(var i = 0; i < i1259.length; i += 2) {
  request.r(i1259[i + 0], i1259[i + 1], 1, i1258, '')
  }
  i1256.multiplyChallengeItemList = i1258
  request.r(i1257[9], i1257[10], 0, i1256, 'giftProgress')
  request.r(i1257[11], i1257[12], 0, i1256, 'textProgress')
  request.r(i1257[13], i1257[14], 0, i1256, 'fxGiftReady')
  request.r(i1257[15], i1257[16], 0, i1256, 'btnClaimGift')
  request.r(i1257[17], i1257[18], 0, i1256, 'textGiftCoin')
  return i1256
}

Deserializers["Crystal.SafeArea"] = function (request, data, root) {
  var i1262 = root || request.c( 'Crystal.SafeArea' )
  var i1263 = data
  i1262.ConformX = !!i1263[0]
  i1262.ConformY = !!i1263[1]
  i1262.Logging = !!i1263[2]
  return i1262
}

Deserializers["ButtonCustom"] = function (request, data, root) {
  var i1264 = root || request.c( 'ButtonCustom' )
  var i1265 = data
  i1264.OnClick = request.d('UnityEngine.UI.Button+ButtonClickedEvent', i1265[0], i1264.OnClick)
  i1264.OnPress = request.d('UnityEngine.UI.Button+ButtonClickedEvent', i1265[1], i1264.OnPress)
  i1264.CanClick = !!i1265[2]
  i1264.HavePressEffect = !!i1265[3]
  i1264.IsPoiterDown = !!i1265[4]
  i1264.IsMoveEnter = !!i1265[5]
  i1264.LocalScale = new pc.Vec3( i1265[6], i1265[7], i1265[8] )
  return i1264
}

Deserializers["UnityEngine.UI.Button+ButtonClickedEvent"] = function (request, data, root) {
  var i1266 = root || request.c( 'UnityEngine.UI.Button+ButtonClickedEvent' )
  var i1267 = data
  i1266.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1267[0], i1266.m_PersistentCalls)
  return i1266
}

Deserializers["UnityEngine.Events.PersistentCallGroup"] = function (request, data, root) {
  var i1268 = root || request.c( 'UnityEngine.Events.PersistentCallGroup' )
  var i1269 = data
  var i1271 = i1269[0]
  var i1270 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Events.PersistentCall')))
  for(var i = 0; i < i1271.length; i += 1) {
    i1270.add(request.d('UnityEngine.Events.PersistentCall', i1271[i + 0]));
  }
  i1268.m_Calls = i1270
  return i1268
}

Deserializers["UnityEngine.Events.PersistentCall"] = function (request, data, root) {
  var i1274 = root || request.c( 'UnityEngine.Events.PersistentCall' )
  var i1275 = data
  request.r(i1275[0], i1275[1], 0, i1274, 'm_Target')
  i1274.m_TargetAssemblyTypeName = i1275[2]
  i1274.m_MethodName = i1275[3]
  i1274.m_Mode = i1275[4]
  i1274.m_Arguments = request.d('UnityEngine.Events.ArgumentCache', i1275[5], i1274.m_Arguments)
  i1274.m_CallState = i1275[6]
  return i1274
}

Deserializers["UnityEngine.Events.ArgumentCache"] = function (request, data, root) {
  var i1276 = root || request.c( 'UnityEngine.Events.ArgumentCache' )
  var i1277 = data
  request.r(i1277[0], i1277[1], 0, i1276, 'm_ObjectArgument')
  i1276.m_ObjectArgumentAssemblyTypeName = i1277[2]
  i1276.m_IntArgument = i1277[3]
  i1276.m_FloatArgument = i1277[4]
  i1276.m_StringArgument = i1277[5]
  i1276.m_BoolArgument = !!i1277[6]
  return i1276
}

Deserializers["UIEffect"] = function (request, data, root) {
  var i1278 = root || request.c( 'UIEffect' )
  var i1279 = data
  i1278.UIEffectType = i1279[0]
  i1278.PlayOnAwake = !!i1279[1]
  i1278.Time = i1279[2]
  i1278.FromScale = new pc.Vec3( i1279[3], i1279[4], i1279[5] )
  i1278.SaveLocalScale = new pc.Vec3( i1279[6], i1279[7], i1279[8] )
  i1278.Strength = i1279[9]
  i1278.MoveType = i1279[10]
  i1278.FromPosition = new pc.Vec3( i1279[11], i1279[12], i1279[13] )
  i1278.DirectionType = i1279[14]
  i1278.Offset = i1279[15]
  i1278.SaveArchorPosition = new pc.Vec3( i1279[16], i1279[17], i1279[18] )
  return i1278
}

Deserializers["TMPro.TextMeshProUGUI"] = function (request, data, root) {
  var i1280 = root || request.c( 'TMPro.TextMeshProUGUI' )
  var i1281 = data
  i1280.m_hasFontAssetChanged = !!i1281[0]
  request.r(i1281[1], i1281[2], 0, i1280, 'm_baseMaterial')
  i1280.m_maskOffset = new pc.Vec4( i1281[3], i1281[4], i1281[5], i1281[6] )
  i1280.m_text = i1281[7]
  i1280.m_isRightToLeft = !!i1281[8]
  request.r(i1281[9], i1281[10], 0, i1280, 'm_fontAsset')
  request.r(i1281[11], i1281[12], 0, i1280, 'm_sharedMaterial')
  var i1283 = i1281[13]
  var i1282 = []
  for(var i = 0; i < i1283.length; i += 2) {
  request.r(i1283[i + 0], i1283[i + 1], 2, i1282, '')
  }
  i1280.m_fontSharedMaterials = i1282
  request.r(i1281[14], i1281[15], 0, i1280, 'm_fontMaterial')
  var i1285 = i1281[16]
  var i1284 = []
  for(var i = 0; i < i1285.length; i += 2) {
  request.r(i1285[i + 0], i1285[i + 1], 2, i1284, '')
  }
  i1280.m_fontMaterials = i1284
  i1280.m_fontColor32 = UnityEngine.Color32.ConstructColor(i1281[17], i1281[18], i1281[19], i1281[20])
  i1280.m_fontColor = new pc.Color(i1281[21], i1281[22], i1281[23], i1281[24])
  i1280.m_enableVertexGradient = !!i1281[25]
  i1280.m_colorMode = i1281[26]
  i1280.m_fontColorGradient = request.d('TMPro.VertexGradient', i1281[27], i1280.m_fontColorGradient)
  request.r(i1281[28], i1281[29], 0, i1280, 'm_fontColorGradientPreset')
  request.r(i1281[30], i1281[31], 0, i1280, 'm_spriteAsset')
  i1280.m_tintAllSprites = !!i1281[32]
  request.r(i1281[33], i1281[34], 0, i1280, 'm_StyleSheet')
  i1280.m_TextStyleHashCode = i1281[35]
  i1280.m_overrideHtmlColors = !!i1281[36]
  i1280.m_faceColor = UnityEngine.Color32.ConstructColor(i1281[37], i1281[38], i1281[39], i1281[40])
  i1280.m_fontSize = i1281[41]
  i1280.m_fontSizeBase = i1281[42]
  i1280.m_fontWeight = i1281[43]
  i1280.m_enableAutoSizing = !!i1281[44]
  i1280.m_fontSizeMin = i1281[45]
  i1280.m_fontSizeMax = i1281[46]
  i1280.m_fontStyle = i1281[47]
  i1280.m_HorizontalAlignment = i1281[48]
  i1280.m_VerticalAlignment = i1281[49]
  i1280.m_textAlignment = i1281[50]
  i1280.m_characterSpacing = i1281[51]
  i1280.m_wordSpacing = i1281[52]
  i1280.m_lineSpacing = i1281[53]
  i1280.m_lineSpacingMax = i1281[54]
  i1280.m_paragraphSpacing = i1281[55]
  i1280.m_charWidthMaxAdj = i1281[56]
  i1280.m_enableWordWrapping = !!i1281[57]
  i1280.m_wordWrappingRatios = i1281[58]
  i1280.m_overflowMode = i1281[59]
  request.r(i1281[60], i1281[61], 0, i1280, 'm_linkedTextComponent')
  request.r(i1281[62], i1281[63], 0, i1280, 'parentLinkedComponent')
  i1280.m_enableKerning = !!i1281[64]
  i1280.m_enableExtraPadding = !!i1281[65]
  i1280.checkPaddingRequired = !!i1281[66]
  i1280.m_isRichText = !!i1281[67]
  i1280.m_parseCtrlCharacters = !!i1281[68]
  i1280.m_isOrthographic = !!i1281[69]
  i1280.m_isCullingEnabled = !!i1281[70]
  i1280.m_horizontalMapping = i1281[71]
  i1280.m_verticalMapping = i1281[72]
  i1280.m_uvLineOffset = i1281[73]
  i1280.m_geometrySortingOrder = i1281[74]
  i1280.m_IsTextObjectScaleStatic = !!i1281[75]
  i1280.m_VertexBufferAutoSizeReduction = !!i1281[76]
  i1280.m_useMaxVisibleDescender = !!i1281[77]
  i1280.m_pageToDisplay = i1281[78]
  i1280.m_margin = new pc.Vec4( i1281[79], i1281[80], i1281[81], i1281[82] )
  i1280.m_isUsingLegacyAnimationComponent = !!i1281[83]
  i1280.m_isVolumetricText = !!i1281[84]
  request.r(i1281[85], i1281[86], 0, i1280, 'm_Material')
  i1280.m_Maskable = !!i1281[87]
  i1280.m_Color = new pc.Color(i1281[88], i1281[89], i1281[90], i1281[91])
  i1280.m_RaycastTarget = !!i1281[92]
  i1280.m_RaycastPadding = new pc.Vec4( i1281[93], i1281[94], i1281[95], i1281[96] )
  return i1280
}

Deserializers["TMPro.VertexGradient"] = function (request, data, root) {
  var i1288 = root || request.c( 'TMPro.VertexGradient' )
  var i1289 = data
  i1288.topLeft = new pc.Color(i1289[0], i1289[1], i1289[2], i1289[3])
  i1288.topRight = new pc.Color(i1289[4], i1289[5], i1289[6], i1289[7])
  i1288.bottomLeft = new pc.Color(i1289[8], i1289[9], i1289[10], i1289[11])
  i1288.bottomRight = new pc.Color(i1289[12], i1289[13], i1289[14], i1289[15])
  return i1288
}

Deserializers["I2.Loc.Localize"] = function (request, data, root) {
  var i1290 = root || request.c( 'I2.Loc.Localize' )
  var i1291 = data
  i1290.mTerm = i1291[0]
  i1290.mTermSecondary = i1291[1]
  i1290.PrimaryTermModifier = i1291[2]
  i1290.SecondaryTermModifier = i1291[3]
  i1290.TermPrefix = i1291[4]
  i1290.TermSuffix = i1291[5]
  i1290.LocalizeOnAwake = !!i1291[6]
  i1290.IgnoreRTL = !!i1291[7]
  i1290.MaxCharactersInRTL = i1291[8]
  i1290.IgnoreNumbersInRTL = !!i1291[9]
  i1290.CorrectAlignmentForRTL = !!i1291[10]
  i1290.AddSpacesToJoinedLanguages = !!i1291[11]
  i1290.AllowLocalizedParameters = !!i1291[12]
  i1290.AllowParameters = !!i1291[13]
  var i1293 = i1291[14]
  var i1292 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Object')))
  for(var i = 0; i < i1293.length; i += 2) {
  request.r(i1293[i + 0], i1293[i + 1], 1, i1292, '')
  }
  i1290.TranslatedObjects = i1292
  i1290.LocalizeEvent = request.d('UnityEngine.Events.UnityEvent', i1291[15], i1290.LocalizeEvent)
  i1290.AlwaysForceLocalize = !!i1291[16]
  i1290.LocalizeCallBack = request.d('I2.Loc.EventCallback', i1291[17], i1290.LocalizeCallBack)
  i1290.mGUI_ShowReferences = !!i1291[18]
  i1290.mGUI_ShowTems = !!i1291[19]
  i1290.mGUI_ShowCallback = !!i1291[20]
  request.r(i1291[21], i1291[22], 0, i1290, 'mLocalizeTarget')
  i1290.mLocalizeTargetName = i1291[23]
  return i1290
}

Deserializers["UnityEngine.Events.UnityEvent"] = function (request, data, root) {
  var i1296 = root || request.c( 'UnityEngine.Events.UnityEvent' )
  var i1297 = data
  i1296.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1297[0], i1296.m_PersistentCalls)
  return i1296
}

Deserializers["I2.Loc.EventCallback"] = function (request, data, root) {
  var i1298 = root || request.c( 'I2.Loc.EventCallback' )
  var i1299 = data
  request.r(i1299[0], i1299[1], 0, i1298, 'Target')
  i1298.MethodName = i1299[2]
  return i1298
}

Deserializers["I2.Loc.LocalizationParamsManager"] = function (request, data, root) {
  var i1300 = root || request.c( 'I2.Loc.LocalizationParamsManager' )
  var i1301 = data
  var i1303 = i1301[0]
  var i1302 = new (System.Collections.Generic.List$1(Bridge.ns('I2.Loc.LocalizationParamsManager+ParamValue')))
  for(var i = 0; i < i1303.length; i += 1) {
    i1302.add(request.d('I2.Loc.LocalizationParamsManager+ParamValue', i1303[i + 0]));
  }
  i1300._Params = i1302
  i1300._IsGlobalManager = !!i1301[1]
  return i1300
}

Deserializers["I2.Loc.LocalizationParamsManager+ParamValue"] = function (request, data, root) {
  var i1306 = root || request.c( 'I2.Loc.LocalizationParamsManager+ParamValue' )
  var i1307 = data
  i1306.Name = i1307[0]
  i1306.Value = i1307[1]
  return i1306
}

Deserializers["UnityEngine.UI.ScrollRect"] = function (request, data, root) {
  var i1308 = root || request.c( 'UnityEngine.UI.ScrollRect' )
  var i1309 = data
  request.r(i1309[0], i1309[1], 0, i1308, 'm_Content')
  i1308.m_Horizontal = !!i1309[2]
  i1308.m_Vertical = !!i1309[3]
  i1308.m_MovementType = i1309[4]
  i1308.m_Elasticity = i1309[5]
  i1308.m_Inertia = !!i1309[6]
  i1308.m_DecelerationRate = i1309[7]
  i1308.m_ScrollSensitivity = i1309[8]
  request.r(i1309[9], i1309[10], 0, i1308, 'm_Viewport')
  request.r(i1309[11], i1309[12], 0, i1308, 'm_HorizontalScrollbar')
  request.r(i1309[13], i1309[14], 0, i1308, 'm_VerticalScrollbar')
  i1308.m_HorizontalScrollbarVisibility = i1309[15]
  i1308.m_VerticalScrollbarVisibility = i1309[16]
  i1308.m_HorizontalScrollbarSpacing = i1309[17]
  i1308.m_VerticalScrollbarSpacing = i1309[18]
  i1308.m_OnValueChanged = request.d('UnityEngine.UI.ScrollRect+ScrollRectEvent', i1309[19], i1308.m_OnValueChanged)
  return i1308
}

Deserializers["UnityEngine.UI.ScrollRect+ScrollRectEvent"] = function (request, data, root) {
  var i1310 = root || request.c( 'UnityEngine.UI.ScrollRect+ScrollRectEvent' )
  var i1311 = data
  i1310.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1311[0], i1310.m_PersistentCalls)
  return i1310
}

Deserializers["UnityEngine.UI.Mask"] = function (request, data, root) {
  var i1312 = root || request.c( 'UnityEngine.UI.Mask' )
  var i1313 = data
  i1312.m_ShowMaskGraphic = !!i1313[0]
  return i1312
}

Deserializers["UnityEngine.UI.GridLayoutGroup"] = function (request, data, root) {
  var i1314 = root || request.c( 'UnityEngine.UI.GridLayoutGroup' )
  var i1315 = data
  i1314.m_StartCorner = i1315[0]
  i1314.m_StartAxis = i1315[1]
  i1314.m_CellSize = new pc.Vec2( i1315[2], i1315[3] )
  i1314.m_Spacing = new pc.Vec2( i1315[4], i1315[5] )
  i1314.m_Constraint = i1315[6]
  i1314.m_ConstraintCount = i1315[7]
  i1314.m_Padding = UnityEngine.RectOffset.FromPaddings(i1315[8], i1315[9], i1315[10], i1315[11])
  i1314.m_ChildAlignment = i1315[12]
  return i1314
}

Deserializers["UnityEngine.UI.ContentSizeFitter"] = function (request, data, root) {
  var i1316 = root || request.c( 'UnityEngine.UI.ContentSizeFitter' )
  var i1317 = data
  i1316.m_HorizontalFit = i1317[0]
  i1316.m_VerticalFit = i1317[1]
  return i1316
}

Deserializers["UnityEngine.UI.Scrollbar"] = function (request, data, root) {
  var i1318 = root || request.c( 'UnityEngine.UI.Scrollbar' )
  var i1319 = data
  request.r(i1319[0], i1319[1], 0, i1318, 'm_HandleRect')
  i1318.m_Direction = i1319[2]
  i1318.m_Value = i1319[3]
  i1318.m_Size = i1319[4]
  i1318.m_NumberOfSteps = i1319[5]
  i1318.m_OnValueChanged = request.d('UnityEngine.UI.Scrollbar+ScrollEvent', i1319[6], i1318.m_OnValueChanged)
  i1318.m_Navigation = request.d('UnityEngine.UI.Navigation', i1319[7], i1318.m_Navigation)
  i1318.m_Transition = i1319[8]
  i1318.m_Colors = request.d('UnityEngine.UI.ColorBlock', i1319[9], i1318.m_Colors)
  i1318.m_SpriteState = request.d('UnityEngine.UI.SpriteState', i1319[10], i1318.m_SpriteState)
  i1318.m_AnimationTriggers = request.d('UnityEngine.UI.AnimationTriggers', i1319[11], i1318.m_AnimationTriggers)
  i1318.m_Interactable = !!i1319[12]
  request.r(i1319[13], i1319[14], 0, i1318, 'm_TargetGraphic')
  return i1318
}

Deserializers["UnityEngine.UI.Scrollbar+ScrollEvent"] = function (request, data, root) {
  var i1320 = root || request.c( 'UnityEngine.UI.Scrollbar+ScrollEvent' )
  var i1321 = data
  i1320.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i1321[0], i1320.m_PersistentCalls)
  return i1320
}

Deserializers["UnityEngine.UI.Navigation"] = function (request, data, root) {
  var i1322 = root || request.c( 'UnityEngine.UI.Navigation' )
  var i1323 = data
  i1322.m_Mode = i1323[0]
  i1322.m_WrapAround = !!i1323[1]
  request.r(i1323[2], i1323[3], 0, i1322, 'm_SelectOnUp')
  request.r(i1323[4], i1323[5], 0, i1322, 'm_SelectOnDown')
  request.r(i1323[6], i1323[7], 0, i1322, 'm_SelectOnLeft')
  request.r(i1323[8], i1323[9], 0, i1322, 'm_SelectOnRight')
  return i1322
}

Deserializers["UnityEngine.UI.ColorBlock"] = function (request, data, root) {
  var i1324 = root || request.c( 'UnityEngine.UI.ColorBlock' )
  var i1325 = data
  i1324.m_NormalColor = new pc.Color(i1325[0], i1325[1], i1325[2], i1325[3])
  i1324.m_HighlightedColor = new pc.Color(i1325[4], i1325[5], i1325[6], i1325[7])
  i1324.m_PressedColor = new pc.Color(i1325[8], i1325[9], i1325[10], i1325[11])
  i1324.m_SelectedColor = new pc.Color(i1325[12], i1325[13], i1325[14], i1325[15])
  i1324.m_DisabledColor = new pc.Color(i1325[16], i1325[17], i1325[18], i1325[19])
  i1324.m_ColorMultiplier = i1325[20]
  i1324.m_FadeDuration = i1325[21]
  return i1324
}

Deserializers["UnityEngine.UI.SpriteState"] = function (request, data, root) {
  var i1326 = root || request.c( 'UnityEngine.UI.SpriteState' )
  var i1327 = data
  request.r(i1327[0], i1327[1], 0, i1326, 'm_HighlightedSprite')
  request.r(i1327[2], i1327[3], 0, i1326, 'm_PressedSprite')
  request.r(i1327[4], i1327[5], 0, i1326, 'm_SelectedSprite')
  request.r(i1327[6], i1327[7], 0, i1326, 'm_DisabledSprite')
  return i1326
}

Deserializers["UnityEngine.UI.AnimationTriggers"] = function (request, data, root) {
  var i1328 = root || request.c( 'UnityEngine.UI.AnimationTriggers' )
  var i1329 = data
  i1328.m_NormalTrigger = i1329[0]
  i1328.m_HighlightedTrigger = i1329[1]
  i1328.m_PressedTrigger = i1329[2]
  i1328.m_SelectedTrigger = i1329[3]
  i1328.m_DisabledTrigger = i1329[4]
  return i1328
}

Deserializers["RotateGameObject"] = function (request, data, root) {
  var i1330 = root || request.c( 'RotateGameObject' )
  var i1331 = data
  i1330.Speed = i1331[0]
  i1330.IsRotationX = !!i1331[1]
  i1330.IsRotationY = !!i1331[2]
  i1330.IsRotationZ = !!i1331[3]
  return i1330
}

Deserializers["LevelChallengeItem"] = function (request, data, root) {
  var i1332 = root || request.c( 'LevelChallengeItem' )
  var i1333 = data
  i1332.Index = i1333[0]
  i1332.Model = request.d('LevelChallengeConfigModel', i1333[1], i1332.Model)
  i1332.UserData = request.d('LevelChallengePlayerData', i1333[2], i1332.UserData)
  i1332._levelChallengeConfig = request.d('LevelChallengeConfig', i1333[3], i1332._levelChallengeConfig)
  request.r(i1333[4], i1333[5], 0, i1332, 'unplayableGo')
  request.r(i1333[6], i1333[7], 0, i1332, 'playableGo')
  request.r(i1333[8], i1333[9], 0, i1332, 'failGo')
  request.r(i1333[10], i1333[11], 0, i1332, 'successGo')
  request.r(i1333[12], i1333[13], 0, i1332, 'playBtn')
  request.r(i1333[14], i1333[15], 0, i1332, 'playAgainBtn')
  request.r(i1333[16], i1333[17], 0, i1332, 'indexText')
  request.r(i1333[18], i1333[19], 0, i1332, 'coinValueText')
  request.r(i1333[20], i1333[21], 0, i1332, 'coinValueText2')
  return i1332
}

Deserializers["LevelChallengeConfigModel"] = function (request, data, root) {
  var i1334 = root || request.c( 'LevelChallengeConfigModel' )
  var i1335 = data
  i1334.Id = i1335[0]
  i1334.LevelUnlock = i1335[1]
  i1334.CoinReward = i1335[2]
  return i1334
}

Deserializers["LevelChallengePlayerData"] = function (request, data, root) {
  var i1336 = root || request.c( 'LevelChallengePlayerData' )
  var i1337 = data
  i1336.id = i1337[0]
  i1336.isPlayed = !!i1337[1]
  i1336.isWined = !!i1337[2]
  i1336.moveLeftNumb = i1337[3]
  return i1336
}

Deserializers["LevelChallengeConfig"] = function (request, data, root) {
  var i1338 = root || request.c( 'LevelChallengeConfig' )
  var i1339 = data
  var i1341 = i1339[0]
  var i1340 = new (System.Collections.Generic.List$1(Bridge.ns('LevelChallengeConfigModel')))
  for(var i = 0; i < i1341.length; i += 1) {
    i1340.add(request.d('LevelChallengeConfigModel', i1341[i + 0]));
  }
  i1338.Datas = i1340
  return i1338
}

Deserializers["MultipleChallengeItem"] = function (request, data, root) {
  var i1344 = root || request.c( 'MultipleChallengeItem' )
  var i1345 = data
  i1344.index = i1345[0]
  i1344.model = request.d('MultipleChallengeConfigModel', i1345[1], i1344.model)
  i1344.data = request.d('MultipleChallengePlayerData', i1345[2], i1344.data)
  request.r(i1345[3], i1345[4], 0, i1344, 'unplayableGo')
  request.r(i1345[5], i1345[6], 0, i1344, 'playableGo')
  request.r(i1345[7], i1345[8], 0, i1344, 'successGo')
  request.r(i1345[9], i1345[10], 0, i1344, 'btnPlayGo')
  request.r(i1345[11], i1345[12], 0, i1344, 'btnPlayAgainGo')
  request.r(i1345[13], i1345[14], 0, i1344, 'indexText')
  return i1344
}

Deserializers["MultipleChallengeConfigModel"] = function (request, data, root) {
  var i1346 = root || request.c( 'MultipleChallengeConfigModel' )
  var i1347 = data
  i1346.Id = i1347[0]
  return i1346
}

Deserializers["MultipleChallengePlayerData"] = function (request, data, root) {
  var i1348 = root || request.c( 'MultipleChallengePlayerData' )
  var i1349 = data
  i1348.id = i1349[0]
  return i1348
}

Deserializers["PopupInGame"] = function (request, data, root) {
  var i1350 = root || request.c( 'PopupInGame' )
  var i1351 = data
  i1350.useAnimation = !!i1351[0]
  request.r(i1351[1], i1351[2], 0, i1350, 'Background')
  i1350.ShowAnimationType = i1351[3]
  i1350.UseHideAnimation = !!i1351[4]
  i1350.HideAnimationType = i1351[5]
  request.r(i1351[6], i1351[7], 0, i1350, 'ConfesttiWin1')
  request.r(i1351[8], i1351[9], 0, i1350, 'ConfesttiWin2')
  return i1350
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.ParticleSystem"] = function (request, data, root) {
  var i1352 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.ParticleSystem' )
  var i1353 = data
  i1352.main = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule', i1353[0], i1352.main)
  i1352.colorBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule', i1353[1], i1352.colorBySpeed)
  i1352.colorOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule', i1353[2], i1352.colorOverLifetime)
  i1352.emission = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule', i1353[3], i1352.emission)
  i1352.rotationBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule', i1353[4], i1352.rotationBySpeed)
  i1352.rotationOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule', i1353[5], i1352.rotationOverLifetime)
  i1352.shape = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule', i1353[6], i1352.shape)
  i1352.sizeBySpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule', i1353[7], i1352.sizeBySpeed)
  i1352.sizeOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule', i1353[8], i1352.sizeOverLifetime)
  i1352.textureSheetAnimation = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule', i1353[9], i1352.textureSheetAnimation)
  i1352.velocityOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule', i1353[10], i1352.velocityOverLifetime)
  i1352.noise = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule', i1353[11], i1352.noise)
  i1352.inheritVelocity = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule', i1353[12], i1352.inheritVelocity)
  i1352.forceOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule', i1353[13], i1352.forceOverLifetime)
  i1352.limitVelocityOverLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule', i1353[14], i1352.limitVelocityOverLifetime)
  i1352.useAutoRandomSeed = !!i1353[15]
  i1352.randomSeed = i1353[16]
  return i1352
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule"] = function (request, data, root) {
  var i1354 = root || new pc.ParticleSystemMain()
  var i1355 = data
  i1354.duration = i1355[0]
  i1354.loop = !!i1355[1]
  i1354.prewarm = !!i1355[2]
  i1354.startDelay = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[3], i1354.startDelay)
  i1354.startLifetime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[4], i1354.startLifetime)
  i1354.startSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[5], i1354.startSpeed)
  i1354.startSize3D = !!i1355[6]
  i1354.startSizeX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[7], i1354.startSizeX)
  i1354.startSizeY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[8], i1354.startSizeY)
  i1354.startSizeZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[9], i1354.startSizeZ)
  i1354.startRotation3D = !!i1355[10]
  i1354.startRotationX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[11], i1354.startRotationX)
  i1354.startRotationY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[12], i1354.startRotationY)
  i1354.startRotationZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[13], i1354.startRotationZ)
  i1354.startColor = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i1355[14], i1354.startColor)
  i1354.gravityModifier = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1355[15], i1354.gravityModifier)
  i1354.simulationSpace = i1355[16]
  request.r(i1355[17], i1355[18], 0, i1354, 'customSimulationSpace')
  i1354.simulationSpeed = i1355[19]
  i1354.useUnscaledTime = !!i1355[20]
  i1354.scalingMode = i1355[21]
  i1354.playOnAwake = !!i1355[22]
  i1354.maxParticles = i1355[23]
  i1354.emitterVelocityMode = i1355[24]
  i1354.stopAction = i1355[25]
  return i1354
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve"] = function (request, data, root) {
  var i1356 = root || new pc.MinMaxCurve()
  var i1357 = data
  i1356.mode = i1357[0]
  i1356.curveMin = new pc.AnimationCurve( { keys_flow: i1357[1] } )
  i1356.curveMax = new pc.AnimationCurve( { keys_flow: i1357[2] } )
  i1356.curveMultiplier = i1357[3]
  i1356.constantMin = i1357[4]
  i1356.constantMax = i1357[5]
  return i1356
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient"] = function (request, data, root) {
  var i1358 = root || new pc.MinMaxGradient()
  var i1359 = data
  i1358.mode = i1359[0]
  i1358.gradientMin = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient', i1359[1], i1358.gradientMin)
  i1358.gradientMax = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient', i1359[2], i1358.gradientMax)
  i1358.colorMin = new pc.Color(i1359[3], i1359[4], i1359[5], i1359[6])
  i1358.colorMax = new pc.Color(i1359[7], i1359[8], i1359[9], i1359[10])
  return i1358
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient"] = function (request, data, root) {
  var i1360 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient' )
  var i1361 = data
  i1360.mode = i1361[0]
  var i1363 = i1361[1]
  var i1362 = []
  for(var i = 0; i < i1363.length; i += 1) {
    i1362.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey', i1363[i + 0]) );
  }
  i1360.colorKeys = i1362
  var i1365 = i1361[2]
  var i1364 = []
  for(var i = 0; i < i1365.length; i += 1) {
    i1364.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey', i1365[i + 0]) );
  }
  i1360.alphaKeys = i1364
  return i1360
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule"] = function (request, data, root) {
  var i1366 = root || new pc.ParticleSystemColorBySpeed()
  var i1367 = data
  i1366.enabled = !!i1367[0]
  i1366.color = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i1367[1], i1366.color)
  i1366.range = new pc.Vec2( i1367[2], i1367[3] )
  return i1366
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey"] = function (request, data, root) {
  var i1370 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey' )
  var i1371 = data
  i1370.color = new pc.Color(i1371[0], i1371[1], i1371[2], i1371[3])
  i1370.time = i1371[4]
  return i1370
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey"] = function (request, data, root) {
  var i1374 = root || request.c( 'Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey' )
  var i1375 = data
  i1374.alpha = i1375[0]
  i1374.time = i1375[1]
  return i1374
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule"] = function (request, data, root) {
  var i1376 = root || new pc.ParticleSystemColorOverLifetime()
  var i1377 = data
  i1376.enabled = !!i1377[0]
  i1376.color = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient', i1377[1], i1376.color)
  return i1376
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule"] = function (request, data, root) {
  var i1378 = root || new pc.ParticleSystemEmitter()
  var i1379 = data
  i1378.enabled = !!i1379[0]
  i1378.rateOverTime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1379[1], i1378.rateOverTime)
  i1378.rateOverDistance = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1379[2], i1378.rateOverDistance)
  var i1381 = i1379[3]
  var i1380 = []
  for(var i = 0; i < i1381.length; i += 1) {
    i1380.push( request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst', i1381[i + 0]) );
  }
  i1378.bursts = i1380
  return i1378
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst"] = function (request, data, root) {
  var i1384 = root || new pc.ParticleSystemBurst()
  var i1385 = data
  i1384.count = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1385[0], i1384.count)
  i1384.cycleCount = i1385[1]
  i1384.minCount = i1385[2]
  i1384.maxCount = i1385[3]
  i1384.repeatInterval = i1385[4]
  i1384.time = i1385[5]
  return i1384
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule"] = function (request, data, root) {
  var i1386 = root || new pc.ParticleSystemRotationBySpeed()
  var i1387 = data
  i1386.enabled = !!i1387[0]
  i1386.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1387[1], i1386.x)
  i1386.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1387[2], i1386.y)
  i1386.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1387[3], i1386.z)
  i1386.separateAxes = !!i1387[4]
  i1386.range = new pc.Vec2( i1387[5], i1387[6] )
  return i1386
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule"] = function (request, data, root) {
  var i1388 = root || new pc.ParticleSystemRotationOverLifetime()
  var i1389 = data
  i1388.enabled = !!i1389[0]
  i1388.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1389[1], i1388.x)
  i1388.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1389[2], i1388.y)
  i1388.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1389[3], i1388.z)
  i1388.separateAxes = !!i1389[4]
  return i1388
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule"] = function (request, data, root) {
  var i1390 = root || new pc.ParticleSystemShape()
  var i1391 = data
  i1390.enabled = !!i1391[0]
  i1390.shapeType = i1391[1]
  i1390.randomDirectionAmount = i1391[2]
  i1390.sphericalDirectionAmount = i1391[3]
  i1390.randomPositionAmount = i1391[4]
  i1390.alignToDirection = !!i1391[5]
  i1390.radius = i1391[6]
  i1390.radiusMode = i1391[7]
  i1390.radiusSpread = i1391[8]
  i1390.radiusSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1391[9], i1390.radiusSpeed)
  i1390.radiusThickness = i1391[10]
  i1390.angle = i1391[11]
  i1390.length = i1391[12]
  i1390.boxThickness = new pc.Vec3( i1391[13], i1391[14], i1391[15] )
  i1390.meshShapeType = i1391[16]
  request.r(i1391[17], i1391[18], 0, i1390, 'mesh')
  request.r(i1391[19], i1391[20], 0, i1390, 'meshRenderer')
  request.r(i1391[21], i1391[22], 0, i1390, 'skinnedMeshRenderer')
  i1390.useMeshMaterialIndex = !!i1391[23]
  i1390.meshMaterialIndex = i1391[24]
  i1390.useMeshColors = !!i1391[25]
  i1390.normalOffset = i1391[26]
  i1390.arc = i1391[27]
  i1390.arcMode = i1391[28]
  i1390.arcSpread = i1391[29]
  i1390.arcSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1391[30], i1390.arcSpeed)
  i1390.donutRadius = i1391[31]
  i1390.position = new pc.Vec3( i1391[32], i1391[33], i1391[34] )
  i1390.rotation = new pc.Vec3( i1391[35], i1391[36], i1391[37] )
  i1390.scale = new pc.Vec3( i1391[38], i1391[39], i1391[40] )
  return i1390
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule"] = function (request, data, root) {
  var i1392 = root || new pc.ParticleSystemSizeBySpeed()
  var i1393 = data
  i1392.enabled = !!i1393[0]
  i1392.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1393[1], i1392.x)
  i1392.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1393[2], i1392.y)
  i1392.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1393[3], i1392.z)
  i1392.separateAxes = !!i1393[4]
  i1392.range = new pc.Vec2( i1393[5], i1393[6] )
  return i1392
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule"] = function (request, data, root) {
  var i1394 = root || new pc.ParticleSystemSizeOverLifetime()
  var i1395 = data
  i1394.enabled = !!i1395[0]
  i1394.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1395[1], i1394.x)
  i1394.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1395[2], i1394.y)
  i1394.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1395[3], i1394.z)
  i1394.separateAxes = !!i1395[4]
  return i1394
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule"] = function (request, data, root) {
  var i1396 = root || new pc.ParticleSystemTextureSheetAnimation()
  var i1397 = data
  i1396.enabled = !!i1397[0]
  i1396.mode = i1397[1]
  i1396.animation = i1397[2]
  i1396.numTilesX = i1397[3]
  i1396.numTilesY = i1397[4]
  i1396.useRandomRow = !!i1397[5]
  i1396.frameOverTime = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1397[6], i1396.frameOverTime)
  i1396.startFrame = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1397[7], i1396.startFrame)
  i1396.cycleCount = i1397[8]
  i1396.rowIndex = i1397[9]
  i1396.flipU = i1397[10]
  i1396.flipV = i1397[11]
  i1396.spriteCount = i1397[12]
  var i1399 = i1397[13]
  var i1398 = []
  for(var i = 0; i < i1399.length; i += 2) {
  request.r(i1399[i + 0], i1399[i + 1], 2, i1398, '')
  }
  i1396.sprites = i1398
  return i1396
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule"] = function (request, data, root) {
  var i1402 = root || new pc.ParticleSystemVelocityOverLifetime()
  var i1403 = data
  i1402.enabled = !!i1403[0]
  i1402.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[1], i1402.x)
  i1402.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[2], i1402.y)
  i1402.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[3], i1402.z)
  i1402.radial = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[4], i1402.radial)
  i1402.speedModifier = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[5], i1402.speedModifier)
  i1402.space = i1403[6]
  i1402.orbitalX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[7], i1402.orbitalX)
  i1402.orbitalY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[8], i1402.orbitalY)
  i1402.orbitalZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[9], i1402.orbitalZ)
  i1402.orbitalOffsetX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[10], i1402.orbitalOffsetX)
  i1402.orbitalOffsetY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[11], i1402.orbitalOffsetY)
  i1402.orbitalOffsetZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1403[12], i1402.orbitalOffsetZ)
  return i1402
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule"] = function (request, data, root) {
  var i1404 = root || new pc.ParticleSystemNoise()
  var i1405 = data
  i1404.enabled = !!i1405[0]
  i1404.separateAxes = !!i1405[1]
  i1404.strengthX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[2], i1404.strengthX)
  i1404.strengthY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[3], i1404.strengthY)
  i1404.strengthZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[4], i1404.strengthZ)
  i1404.frequency = i1405[5]
  i1404.damping = !!i1405[6]
  i1404.octaveCount = i1405[7]
  i1404.octaveMultiplier = i1405[8]
  i1404.octaveScale = i1405[9]
  i1404.quality = i1405[10]
  i1404.scrollSpeed = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[11], i1404.scrollSpeed)
  i1404.scrollSpeedMultiplier = i1405[12]
  i1404.remapEnabled = !!i1405[13]
  i1404.remapX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[14], i1404.remapX)
  i1404.remapY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[15], i1404.remapY)
  i1404.remapZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[16], i1404.remapZ)
  i1404.positionAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[17], i1404.positionAmount)
  i1404.rotationAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[18], i1404.rotationAmount)
  i1404.sizeAmount = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1405[19], i1404.sizeAmount)
  return i1404
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule"] = function (request, data, root) {
  var i1406 = root || new pc.ParticleSystemInheritVelocity()
  var i1407 = data
  i1406.enabled = !!i1407[0]
  i1406.mode = i1407[1]
  i1406.curve = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1407[2], i1406.curve)
  return i1406
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule"] = function (request, data, root) {
  var i1408 = root || new pc.ParticleSystemForceOverLifetime()
  var i1409 = data
  i1408.enabled = !!i1409[0]
  i1408.x = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1409[1], i1408.x)
  i1408.y = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1409[2], i1408.y)
  i1408.z = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1409[3], i1408.z)
  i1408.space = i1409[4]
  i1408.randomized = !!i1409[5]
  return i1408
}

Deserializers["Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule"] = function (request, data, root) {
  var i1410 = root || new pc.ParticleSystemLimitVelocityOverLifetime()
  var i1411 = data
  i1410.enabled = !!i1411[0]
  i1410.limit = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1411[1], i1410.limit)
  i1410.limitX = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1411[2], i1410.limitX)
  i1410.limitY = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1411[3], i1410.limitY)
  i1410.limitZ = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1411[4], i1410.limitZ)
  i1410.dampen = i1411[5]
  i1410.separateAxes = !!i1411[6]
  i1410.space = i1411[7]
  i1410.drag = request.d('Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve', i1411[8], i1410.drag)
  i1410.multiplyDragByParticleSize = !!i1411[9]
  i1410.multiplyDragByParticleVelocity = !!i1411[10]
  return i1410
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer"] = function (request, data, root) {
  var i1412 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer' )
  var i1413 = data
  i1412.enabled = !!i1413[0]
  request.r(i1413[1], i1413[2], 0, i1412, 'sharedMaterial')
  var i1415 = i1413[3]
  var i1414 = []
  for(var i = 0; i < i1415.length; i += 2) {
  request.r(i1415[i + 0], i1415[i + 1], 2, i1414, '')
  }
  i1412.sharedMaterials = i1414
  i1412.receiveShadows = !!i1413[4]
  i1412.shadowCastingMode = i1413[5]
  i1412.sortingLayerID = i1413[6]
  i1412.sortingOrder = i1413[7]
  i1412.lightmapIndex = i1413[8]
  i1412.lightmapSceneIndex = i1413[9]
  i1412.lightmapScaleOffset = new pc.Vec4( i1413[10], i1413[11], i1413[12], i1413[13] )
  i1412.lightProbeUsage = i1413[14]
  i1412.reflectionProbeUsage = i1413[15]
  request.r(i1413[16], i1413[17], 0, i1412, 'mesh')
  i1412.meshCount = i1413[18]
  i1412.activeVertexStreamsCount = i1413[19]
  i1412.alignment = i1413[20]
  i1412.renderMode = i1413[21]
  i1412.sortMode = i1413[22]
  i1412.lengthScale = i1413[23]
  i1412.velocityScale = i1413[24]
  i1412.cameraVelocityScale = i1413[25]
  i1412.normalDirection = i1413[26]
  i1412.sortingFudge = i1413[27]
  i1412.minParticleSize = i1413[28]
  i1412.maxParticleSize = i1413[29]
  i1412.pivot = new pc.Vec3( i1413[30], i1413[31], i1413[32] )
  request.r(i1413[33], i1413[34], 0, i1412, 'trailMaterial')
  return i1412
}

Deserializers["Coffee.UIExtensions.UIParticle"] = function (request, data, root) {
  var i1416 = root || request.c( 'Coffee.UIExtensions.UIParticle' )
  var i1417 = data
  i1416.m_IsTrail = !!i1417[0]
  i1416.m_IgnoreCanvasScaler = !!i1417[1]
  i1416.m_Scale = i1417[2]
  i1416.m_Scale3D = new pc.Vec3( i1417[3], i1417[4], i1417[5] )
  var i1419 = i1417[6]
  var i1418 = []
  for(var i = 0; i < i1419.length; i += 1) {
    i1418.push( request.d('Coffee.UIExtensions.AnimatableProperty', i1419[i + 0]) );
  }
  i1416.m_AnimatableProperties = i1418
  var i1421 = i1417[7]
  var i1420 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.ParticleSystem')))
  for(var i = 0; i < i1421.length; i += 2) {
  request.r(i1421[i + 0], i1421[i + 1], 1, i1420, '')
  }
  i1416.m_Particles = i1420
  i1416.m_ShrinkByMaterial = !!i1417[8]
  request.r(i1417[9], i1417[10], 0, i1416, 'm_Material')
  i1416.m_Maskable = !!i1417[11]
  i1416.m_Color = new pc.Color(i1417[12], i1417[13], i1417[14], i1417[15])
  i1416.m_RaycastTarget = !!i1417[16]
  i1416.m_RaycastPadding = new pc.Vec4( i1417[17], i1417[18], i1417[19], i1417[20] )
  return i1416
}

Deserializers["Coffee.UIExtensions.AnimatableProperty"] = function (request, data, root) {
  var i1424 = root || request.c( 'Coffee.UIExtensions.AnimatableProperty' )
  var i1425 = data
  i1424.m_Name = i1425[0]
  i1424.m_Type = i1425[1]
  return i1424
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Mesh"] = function (request, data, root) {
  var i1428 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Mesh' )
  var i1429 = data
  i1428.name = i1429[0]
  i1428.halfPrecision = !!i1429[1]
  i1428.useUInt32IndexFormat = !!i1429[2]
  i1428.vertexCount = i1429[3]
  i1428.aabb = i1429[4]
  var i1431 = i1429[5]
  var i1430 = []
  for(var i = 0; i < i1431.length; i += 1) {
    i1430.push( !!i1431[i + 0] );
  }
  i1428.streams = i1430
  i1428.vertices = i1429[6]
  var i1433 = i1429[7]
  var i1432 = []
  for(var i = 0; i < i1433.length; i += 1) {
    i1432.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Mesh+SubMesh', i1433[i + 0]) );
  }
  i1428.subMeshes = i1432
  var i1435 = i1429[8]
  var i1434 = []
  for(var i = 0; i < i1435.length; i += 16) {
    i1434.push( new pc.Mat4().setData(i1435[i + 0], i1435[i + 1], i1435[i + 2], i1435[i + 3],  i1435[i + 4], i1435[i + 5], i1435[i + 6], i1435[i + 7],  i1435[i + 8], i1435[i + 9], i1435[i + 10], i1435[i + 11],  i1435[i + 12], i1435[i + 13], i1435[i + 14], i1435[i + 15]) );
  }
  i1428.bindposes = i1434
  var i1437 = i1429[9]
  var i1436 = []
  for(var i = 0; i < i1437.length; i += 1) {
    i1436.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShape', i1437[i + 0]) );
  }
  i1428.blendShapes = i1436
  return i1428
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Mesh+SubMesh"] = function (request, data, root) {
  var i1442 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Mesh+SubMesh' )
  var i1443 = data
  i1442.triangles = i1443[0]
  return i1442
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShape"] = function (request, data, root) {
  var i1448 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShape' )
  var i1449 = data
  i1448.name = i1449[0]
  var i1451 = i1449[1]
  var i1450 = []
  for(var i = 0; i < i1451.length; i += 1) {
    i1450.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShapeFrame', i1451[i + 0]) );
  }
  i1448.frames = i1450
  return i1448
}

Deserializers["PopupInGameChallenge"] = function (request, data, root) {
  var i1452 = root || request.c( 'PopupInGameChallenge' )
  var i1453 = data
  i1452.useAnimation = !!i1453[0]
  request.r(i1453[1], i1453[2], 0, i1452, 'Background')
  i1452.ShowAnimationType = i1453[3]
  i1452.UseHideAnimation = !!i1453[4]
  i1452.HideAnimationType = i1453[5]
  request.r(i1453[6], i1453[7], 0, i1452, 'LevelText')
  request.r(i1453[8], i1453[9], 0, i1452, 'MoveLeftText')
  request.r(i1453[10], i1453[11], 0, i1452, 'ConfesttiWin1')
  request.r(i1453[12], i1453[13], 0, i1452, 'ConfesttiWin2')
  return i1452
}

Deserializers["PopupIngameMultiple"] = function (request, data, root) {
  var i1454 = root || request.c( 'PopupIngameMultiple' )
  var i1455 = data
  i1454.useAnimation = !!i1455[0]
  request.r(i1455[1], i1455[2], 0, i1454, 'Background')
  i1454.ShowAnimationType = i1455[3]
  i1454.UseHideAnimation = !!i1455[4]
  i1454.HideAnimationType = i1455[5]
  request.r(i1455[6], i1455[7], 0, i1454, 'txtLevel')
  request.r(i1455[8], i1455[9], 0, i1454, 'fxWin1')
  request.r(i1455[10], i1455[11], 0, i1454, 'fxWin2')
  request.r(i1455[12], i1455[13], 0, i1454, 'txtBall')
  return i1454
}

Deserializers["PopupLose"] = function (request, data, root) {
  var i1456 = root || request.c( 'PopupLose' )
  var i1457 = data
  i1456.useAnimation = !!i1457[0]
  request.r(i1457[1], i1457[2], 0, i1456, 'Background')
  i1456.ShowAnimationType = i1457[3]
  i1456.UseHideAnimation = !!i1457[4]
  i1456.HideAnimationType = i1457[5]
  return i1456
}

Deserializers["UnityEngine.UI.VerticalLayoutGroup"] = function (request, data, root) {
  var i1458 = root || request.c( 'UnityEngine.UI.VerticalLayoutGroup' )
  var i1459 = data
  i1458.m_Spacing = i1459[0]
  i1458.m_ChildForceExpandWidth = !!i1459[1]
  i1458.m_ChildForceExpandHeight = !!i1459[2]
  i1458.m_ChildControlWidth = !!i1459[3]
  i1458.m_ChildControlHeight = !!i1459[4]
  i1458.m_ChildScaleWidth = !!i1459[5]
  i1458.m_ChildScaleHeight = !!i1459[6]
  i1458.m_ReverseArrangement = !!i1459[7]
  i1458.m_Padding = UnityEngine.RectOffset.FromPaddings(i1459[8], i1459[9], i1459[10], i1459[11])
  i1458.m_ChildAlignment = i1459[12]
  return i1458
}

Deserializers["BannerCollapsible"] = function (request, data, root) {
  var i1460 = root || request.c( 'BannerCollapsible' )
  var i1461 = data
  i1460.offSetX = i1461[0]
  i1460.offSetY = i1461[1]
  return i1460
}

Deserializers["Spine.Unity.SkeletonGraphic"] = function (request, data, root) {
  var i1462 = root || request.c( 'Spine.Unity.SkeletonGraphic' )
  var i1463 = data
  request.r(i1463[0], i1463[1], 0, i1462, 'skeletonDataAsset')
  request.r(i1463[2], i1463[3], 0, i1462, 'additiveMaterial')
  request.r(i1463[4], i1463[5], 0, i1462, 'multiplyMaterial')
  request.r(i1463[6], i1463[7], 0, i1462, 'screenMaterial')
  i1462.initialSkinName = i1463[8]
  i1462.initialFlipX = !!i1463[9]
  i1462.initialFlipY = !!i1463[10]
  i1462.startingAnimation = i1463[11]
  i1462.startingLoop = !!i1463[12]
  i1462.timeScale = i1463[13]
  i1462.freeze = !!i1463[14]
  i1462.updateWhenInvisible = i1463[15]
  i1462.unscaledTime = !!i1463[16]
  i1462.allowMultipleCanvasRenderers = !!i1463[17]
  var i1465 = i1463[18]
  var i1464 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.CanvasRenderer')))
  for(var i = 0; i < i1465.length; i += 2) {
  request.r(i1465[i + 0], i1465[i + 1], 1, i1464, '')
  }
  i1462.canvasRenderers = i1464
  i1462.enableSeparatorSlots = !!i1463[19]
  i1462.updateSeparatorPartLocation = !!i1463[20]
  var i1467 = i1463[21]
  var i1466 = []
  for(var i = 0; i < i1467.length; i += 1) {
    i1466.push( i1467[i + 0] );
  }
  i1462.separatorSlotNames = i1466
  var i1469 = i1463[22]
  var i1468 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Transform')))
  for(var i = 0; i < i1469.length; i += 2) {
  request.r(i1469[i + 0], i1469[i + 1], 1, i1468, '')
  }
  i1462.separatorParts = i1468
  i1462.meshGenerator = request.d('Spine.Unity.MeshGenerator', i1463[23], i1462.meshGenerator)
  request.r(i1463[24], i1463[25], 0, i1462, 'm_Material')
  i1462.m_Maskable = !!i1463[26]
  i1462.m_Color = new pc.Color(i1463[27], i1463[28], i1463[29], i1463[30])
  i1462.m_RaycastTarget = !!i1463[31]
  i1462.m_RaycastPadding = new pc.Vec4( i1463[32], i1463[33], i1463[34], i1463[35] )
  return i1462
}

Deserializers["Spine.Unity.MeshGenerator"] = function (request, data, root) {
  var i1476 = root || request.c( 'Spine.Unity.MeshGenerator' )
  var i1477 = data
  i1476.settings = request.d('Spine.Unity.MeshGenerator+Settings', i1477[0], i1476.settings)
  return i1476
}

Deserializers["Spine.Unity.MeshGenerator+Settings"] = function (request, data, root) {
  var i1478 = root || request.c( 'Spine.Unity.MeshGenerator+Settings' )
  var i1479 = data
  i1478.useClipping = !!i1479[0]
  i1478.zSpacing = i1479[1]
  i1478.pmaVertexColors = !!i1479[2]
  i1478.tintBlack = !!i1479[3]
  i1478.canvasGroupTintBlack = !!i1479[4]
  i1478.calculateTangents = !!i1479[5]
  i1478.addNormals = !!i1479[6]
  i1478.immutableTriangles = !!i1479[7]
  return i1478
}

Deserializers["PopupUI"] = function (request, data, root) {
  var i1480 = root || request.c( 'PopupUI' )
  var i1481 = data
  i1480.useAnimation = !!i1481[0]
  request.r(i1481[1], i1481[2], 0, i1480, 'Background')
  i1480.ShowAnimationType = i1481[3]
  i1480.UseHideAnimation = !!i1481[4]
  i1480.HideAnimationType = i1481[5]
  return i1480
}

Deserializers["CurrencyCounter"] = function (request, data, root) {
  var i1482 = root || request.c( 'CurrencyCounter' )
  var i1483 = data
  request.r(i1483[0], i1483[1], 0, i1482, 'CurrencyAmountText')
  i1482.StepCount = i1483[2]
  i1482.DelayTime = i1483[3]
  request.r(i1483[4], i1483[5], 0, i1482, 'CurrencyGenerate')
  return i1482
}

Deserializers["CurrencyGenerate"] = function (request, data, root) {
  var i1484 = root || request.c( 'CurrencyGenerate' )
  var i1485 = data
  request.r(i1485[0], i1485[1], 0, i1484, 'overlay')
  request.r(i1485[2], i1485[3], 0, i1484, 'coinPrefab')
  request.r(i1485[4], i1485[5], 0, i1484, 'from')
  request.r(i1485[6], i1485[7], 0, i1484, 'to')
  i1484.numberCoin = i1485[8]
  i1484.delay = i1485[9]
  i1484.durationNear = i1485[10]
  i1484.durationTarget = i1485[11]
  i1484.easeNear = i1485[12]
  i1484.easeTarget = i1485[13]
  i1484.scale = i1485[14]
  return i1484
}

Deserializers["PopupWin"] = function (request, data, root) {
  var i1486 = root || request.c( 'PopupWin' )
  var i1487 = data
  i1486.useAnimation = !!i1487[0]
  request.r(i1487[1], i1487[2], 0, i1486, 'Background')
  i1486.ShowAnimationType = i1487[3]
  i1486.UseHideAnimation = !!i1487[4]
  i1486.HideAnimationType = i1487[5]
  request.r(i1487[6], i1487[7], 0, i1486, 'TapToContinueBtn')
  request.r(i1487[8], i1487[9], 0, i1486, 'RewardAdsBtn')
  return i1486
}

Deserializers["Level"] = function (request, data, root) {
  var i1488 = root || request.c( 'Level' )
  var i1489 = data
  i1488.ScoreWin = i1489[0]
  i1488.cameraLayerMask = UnityEngine.LayerMask.FromIntegerValue( i1489[1] )
  i1488.isShowTutorialBg = !!i1489[2]
  i1488.BonusCoin = i1489[3]
  i1488.notificationType = i1489[4]
  i1488.iconType = i1489[5]
  request.r(i1489[6], i1489[7], 0, i1488, 'customImage')
  i1488.TotalScoreCanGet = i1489[8]
  i1488.InactiveBallsNumb = i1489[9]
  i1488.BallBreakNumb = i1489[10]
  i1488.BombExplodeNumb = i1489[11]
  i1488.PinDragNumb = i1489[12]
  i1488.isGetEventItem = !!i1489[13]
  i1488.usingCustomIcon = !!i1489[14]
  i1488.currentScore = i1489[15]
  i1488.totalCoin = i1489[16]
  return i1488
}

Deserializers["BallHolder2D"] = function (request, data, root) {
  var i1490 = root || request.c( 'BallHolder2D' )
  var i1491 = data
  request.r(i1491[0], i1491[1], 0, i1490, 'Text')
  i1490.IsBroken = !!i1491[2]
  request.r(i1491[3], i1491[4], 0, i1490, 'trigger')
  var i1493 = i1491[5]
  var i1492 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.MeshRenderer')))
  for(var i = 0; i < i1493.length; i += 2) {
  request.r(i1493[i + 0], i1493[i + 1], 1, i1492, '')
  }
  i1490.MeshRenderers = i1492
  request.r(i1491[6], i1491[7], 0, i1490, 'GreenTick')
  request.r(i1491[8], i1491[9], 0, i1490, 'CanvasTransform')
  i1490.DistanceDown = i1491[10]
  return i1490
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Rigidbody"] = function (request, data, root) {
  var i1496 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Rigidbody' )
  var i1497 = data
  i1496.mass = i1497[0]
  i1496.drag = i1497[1]
  i1496.angularDrag = i1497[2]
  i1496.useGravity = !!i1497[3]
  i1496.isKinematic = !!i1497[4]
  i1496.constraints = i1497[5]
  i1496.maxAngularVelocity = i1497[6]
  i1496.collisionDetectionMode = i1497[7]
  i1496.interpolation = i1497[8]
  return i1496
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.BoxCollider"] = function (request, data, root) {
  var i1498 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.BoxCollider' )
  var i1499 = data
  i1498.center = new pc.Vec3( i1499[0], i1499[1], i1499[2] )
  i1498.size = new pc.Vec3( i1499[3], i1499[4], i1499[5] )
  i1498.enabled = !!i1499[6]
  i1498.isTrigger = !!i1499[7]
  request.r(i1499[8], i1499[9], 0, i1498, 'material')
  return i1498
}

Deserializers["BallHolderSkin"] = function (request, data, root) {
  var i1500 = root || request.c( 'BallHolderSkin' )
  var i1501 = data
  i1500.Id = i1501[0]
  var i1503 = i1501[1]
  var i1502 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.MeshRenderer')))
  for(var i = 0; i < i1503.length; i += 2) {
  request.r(i1503[i + 0], i1503[i + 1], 1, i1502, '')
  }
  i1500.objectRenderers = i1502
  request.r(i1501[2], i1501[3], 0, i1500, 'glassRenderer')
  request.r(i1501[4], i1501[5], 0, i1500, 'objectBurnMaterial')
  request.r(i1501[6], i1501[7], 0, i1500, 'glassBurnMaterial')
  return i1500
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.MeshFilter"] = function (request, data, root) {
  var i1504 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.MeshFilter' )
  var i1505 = data
  request.r(i1505[0], i1505[1], 0, i1504, 'sharedMesh')
  return i1504
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.MeshRenderer"] = function (request, data, root) {
  var i1506 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.MeshRenderer' )
  var i1507 = data
  request.r(i1507[0], i1507[1], 0, i1506, 'additionalVertexStreams')
  i1506.enabled = !!i1507[2]
  request.r(i1507[3], i1507[4], 0, i1506, 'sharedMaterial')
  var i1509 = i1507[5]
  var i1508 = []
  for(var i = 0; i < i1509.length; i += 2) {
  request.r(i1509[i + 0], i1509[i + 1], 2, i1508, '')
  }
  i1506.sharedMaterials = i1508
  i1506.receiveShadows = !!i1507[6]
  i1506.shadowCastingMode = i1507[7]
  i1506.sortingLayerID = i1507[8]
  i1506.sortingOrder = i1507[9]
  i1506.lightmapIndex = i1507[10]
  i1506.lightmapSceneIndex = i1507[11]
  i1506.lightmapScaleOffset = new pc.Vec4( i1507[12], i1507[13], i1507[14], i1507[15] )
  i1506.lightProbeUsage = i1507[16]
  i1506.reflectionProbeUsage = i1507[17]
  return i1506
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D"] = function (request, data, root) {
  var i1510 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D' )
  var i1511 = data
  i1510.usedByComposite = !!i1511[0]
  i1510.autoTiling = !!i1511[1]
  i1510.size = new pc.Vec2( i1511[2], i1511[3] )
  i1510.edgeRadius = i1511[4]
  i1510.enabled = !!i1511[5]
  i1510.isTrigger = !!i1511[6]
  i1510.usedByEffector = !!i1511[7]
  i1510.density = i1511[8]
  i1510.offset = new pc.Vec2( i1511[9], i1511[10] )
  request.r(i1511[11], i1511[12], 0, i1510, 'material')
  return i1510
}

Deserializers["UnityEngine.UI.CanvasScaler"] = function (request, data, root) {
  var i1512 = root || request.c( 'UnityEngine.UI.CanvasScaler' )
  var i1513 = data
  i1512.m_UiScaleMode = i1513[0]
  i1512.m_ReferencePixelsPerUnit = i1513[1]
  i1512.m_ScaleFactor = i1513[2]
  i1512.m_ReferenceResolution = new pc.Vec2( i1513[3], i1513[4] )
  i1512.m_ScreenMatchMode = i1513[5]
  i1512.m_MatchWidthOrHeight = i1513[6]
  i1512.m_PhysicalUnit = i1513[7]
  i1512.m_FallbackScreenDPI = i1513[8]
  i1512.m_DefaultSpriteDPI = i1513[9]
  i1512.m_DynamicPixelsPerUnit = i1513[10]
  i1512.m_PresetInfoIsWorld = !!i1513[11]
  return i1512
}

Deserializers["Background"] = function (request, data, root) {
  var i1514 = root || request.c( 'Background' )
  var i1515 = data
  request.r(i1515[0], i1515[1], 0, i1514, 'SkinHolder')
  request.r(i1515[2], i1515[3], 0, i1514, 'tutorialBg')
  return i1514
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Camera"] = function (request, data, root) {
  var i1516 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Camera' )
  var i1517 = data
  i1516.enabled = !!i1517[0]
  i1516.aspect = i1517[1]
  i1516.orthographic = !!i1517[2]
  i1516.orthographicSize = i1517[3]
  i1516.backgroundColor = new pc.Color(i1517[4], i1517[5], i1517[6], i1517[7])
  i1516.nearClipPlane = i1517[8]
  i1516.farClipPlane = i1517[9]
  i1516.fieldOfView = i1517[10]
  i1516.depth = i1517[11]
  i1516.clearFlags = i1517[12]
  i1516.cullingMask = i1517[13]
  i1516.rect = i1517[14]
  request.r(i1517[15], i1517[16], 0, i1516, 'targetTexture')
  i1516.usePhysicalProperties = !!i1517[17]
  i1516.focalLength = i1517[18]
  i1516.sensorSize = new pc.Vec2( i1517[19], i1517[20] )
  i1516.lensShift = new pc.Vec2( i1517[21], i1517[22] )
  i1516.gateFit = i1517[23]
  i1516.commandBufferCount = i1517[24]
  i1516.cameraType = i1517[25]
  return i1516
}

Deserializers["BackgroundSkin"] = function (request, data, root) {
  var i1518 = root || request.c( 'BackgroundSkin' )
  var i1519 = data
  return i1518
}

Deserializers["Destroyer"] = function (request, data, root) {
  var i1520 = root || request.c( 'Destroyer' )
  var i1521 = data
  return i1520
}

Deserializers["Dreamteck.Splines.SplineComputer"] = function (request, data, root) {
  var i1522 = root || request.c( 'Dreamteck.Splines.SplineComputer' )
  var i1523 = data
  i1522.editorDrawPivot = !!i1523[0]
  i1522.editorPathColor = new pc.Color(i1523[1], i1523[2], i1523[3], i1523[4])
  i1522.editorAlwaysDraw = !!i1523[5]
  i1522.editorDrawThickness = !!i1523[6]
  i1522.editorBillboardThickness = !!i1523[7]
  i1522.isNewlyCreated = !!i1523[8]
  i1522.editorUpdateMode = i1523[9]
  i1522.multithreaded = !!i1523[10]
  i1522.updateMode = i1523[11]
  var i1525 = i1523[12]
  var i1524 = []
  for(var i = 0; i < i1525.length; i += 1) {
    i1524.push( request.d('Dreamteck.Splines.TriggerGroup', i1525[i + 0]) );
  }
  i1522.triggerGroups = i1524
  i1522._spline = request.d('Dreamteck.Splines.Spline', i1523[13], i1522._spline)
  i1522._originalSamplePercents = i1523[14]
  i1522._is2D = !!i1523[15]
  i1522.hasSamples = !!i1523[16]
  i1522._optimizeAngleThreshold = i1523[17]
  i1522._space = i1523[18]
  i1522._sampleMode = i1523[19]
  var i1527 = i1523[20]
  var i1526 = []
  for(var i = 0; i < i1527.length; i += 2) {
  request.r(i1527[i + 0], i1527[i + 1], 2, i1526, '')
  }
  i1522._subscribers = i1526
  var i1529 = i1523[21]
  var i1528 = []
  for(var i = 0; i < i1529.length; i += 1) {
    i1528.push( request.d('Dreamteck.Splines.SplineSample', i1529[i + 0]) );
  }
  i1522._rawSamples = i1528
  var i1531 = i1523[22]
  var i1530 = []
  for(var i = 0; i < i1531.length; i += 1) {
    i1530.push( request.d('Dreamteck.Splines.SplineComputer+NodeLink', i1531[i + 0]) );
  }
  i1522._nodes = i1530
  return i1522
}

Deserializers["Dreamteck.Splines.TriggerGroup"] = function (request, data, root) {
  var i1534 = root || request.c( 'Dreamteck.Splines.TriggerGroup' )
  var i1535 = data
  i1534.open = !!i1535[0]
  i1534.enabled = !!i1535[1]
  i1534.name = i1535[2]
  i1534.color = new pc.Color(i1535[3], i1535[4], i1535[5], i1535[6])
  var i1537 = i1535[7]
  var i1536 = []
  for(var i = 0; i < i1537.length; i += 1) {
    i1536.push( request.d('Dreamteck.Splines.SplineTrigger', i1537[i + 0]) );
  }
  i1534.triggers = i1536
  return i1534
}

Deserializers["Dreamteck.Splines.Spline"] = function (request, data, root) {
  var i1538 = root || request.c( 'Dreamteck.Splines.Spline' )
  var i1539 = data
  var i1541 = i1539[0]
  var i1540 = []
  for(var i = 0; i < i1541.length; i += 1) {
    i1540.push( request.d('Dreamteck.Splines.SplinePoint', i1541[i + 0]) );
  }
  i1538.points = i1540
  i1538.type = i1539[1]
  i1538.linearAverageDirection = !!i1539[2]
  i1538.customValueInterpolation = new pc.AnimationCurve( { keys_flow: i1539[3] } )
  i1538.customNormalInterpolation = new pc.AnimationCurve( { keys_flow: i1539[4] } )
  i1538.sampleRate = i1539[5]
  i1538.closed = !!i1539[6]
  i1538._knotParametrization = i1539[7]
  return i1538
}

Deserializers["Dreamteck.Splines.SplinePoint"] = function (request, data, root) {
  var i1544 = root || request.c( 'Dreamteck.Splines.SplinePoint' )
  var i1545 = data
  i1544.position = new pc.Vec3( i1545[0], i1545[1], i1545[2] )
  i1544.color = new pc.Color(i1545[3], i1545[4], i1545[5], i1545[6])
  i1544.normal = new pc.Vec3( i1545[7], i1545[8], i1545[9] )
  i1544.size = i1545[10]
  i1544.tangent = new pc.Vec3( i1545[11], i1545[12], i1545[13] )
  i1544.tangent2 = new pc.Vec3( i1545[14], i1545[15], i1545[16] )
  i1544._type = i1545[17]
  return i1544
}

Deserializers["Dreamteck.Splines.SplineSample"] = function (request, data, root) {
  var i1550 = root || request.c( 'Dreamteck.Splines.SplineSample' )
  var i1551 = data
  i1550.position = new pc.Vec3( i1551[0], i1551[1], i1551[2] )
  i1550.up = new pc.Vec3( i1551[3], i1551[4], i1551[5] )
  i1550.forward = new pc.Vec3( i1551[6], i1551[7], i1551[8] )
  i1550.color = new pc.Color(i1551[9], i1551[10], i1551[11], i1551[12])
  i1550.size = i1551[13]
  i1550.percent = i1551[14]
  return i1550
}

Deserializers["Dreamteck.Splines.SplineComputer+NodeLink"] = function (request, data, root) {
  var i1554 = root || request.c( 'Dreamteck.Splines.SplineComputer+NodeLink' )
  var i1555 = data
  request.r(i1555[0], i1555[1], 0, i1554, 'node')
  i1554.pointIndex = i1555[2]
  return i1554
}

Deserializers["Wall"] = function (request, data, root) {
  var i1556 = root || request.c( 'Wall' )
  var i1557 = data
  request.r(i1557[0], i1557[1], 0, i1556, 'MeshRenderer')
  return i1556
}

Deserializers["Dreamteck.Splines.SplineMesh"] = function (request, data, root) {
  var i1558 = root || request.c( 'Dreamteck.Splines.SplineMesh' )
  var i1559 = data
  i1558.colliderUpdateRate = i1559[0]
  i1558.updateMethod = i1559[1]
  i1558.multithreaded = !!i1559[2]
  i1558.buildOnAwake = !!i1559[3]
  i1558.buildOnEnable = !!i1559[4]
  var i1561 = i1559[5]
  var i1560 = new (System.Collections.Generic.List$1(Bridge.ns('Dreamteck.Splines.SplineMesh+Channel')))
  for(var i = 0; i < i1561.length; i += 1) {
    i1560.add(request.d('Dreamteck.Splines.SplineMesh+Channel', i1561[i + 0]));
  }
  i1558._channels = i1560
  i1558._rotationModifier = request.d('Dreamteck.Splines.RotationModifier', i1559[6], i1558._rotationModifier)
  i1558._offsetModifier = request.d('Dreamteck.Splines.OffsetModifier', i1559[7], i1558._offsetModifier)
  i1558._colorModifier = request.d('Dreamteck.Splines.ColorModifier', i1559[8], i1558._colorModifier)
  i1558._sizeModifier = request.d('Dreamteck.Splines.SizeModifier', i1559[9], i1558._sizeModifier)
  i1558._baked = !!i1559[10]
  i1558._markDynamic = !!i1559[11]
  i1558._size = i1559[12]
  i1558._color = new pc.Color(i1559[13], i1559[14], i1559[15], i1559[16])
  i1558._offset = new pc.Vec3( i1559[17], i1559[18], i1559[19] )
  i1558._normalMethod = i1559[20]
  i1558._calculateTangents = !!i1559[21]
  i1558._useSplineSize = !!i1559[22]
  i1558._useSplineColor = !!i1559[23]
  i1558._rotation = i1559[24]
  i1558._flipFaces = !!i1559[25]
  i1558._doubleSided = !!i1559[26]
  i1558._uvMode = i1559[27]
  i1558._uvScale = new pc.Vec2( i1559[28], i1559[29] )
  i1558._uvOffset = new pc.Vec2( i1559[30], i1559[31] )
  i1558._uvRotation = i1559[32]
  i1558._meshIndexFormat = i1559[33]
  request.r(i1559[34], i1559[35], 0, i1558, '_bakedMesh')
  request.r(i1559[36], i1559[37], 0, i1558, '_spline')
  i1558._autoUpdate = !!i1559[38]
  i1558._clipFromSample = request.d('Dreamteck.Splines.SplineSample', i1559[39], i1558._clipFromSample)
  i1558._clipToSample = request.d('Dreamteck.Splines.SplineSample', i1559[40], i1558._clipToSample)
  i1558._loopSamples = !!i1559[41]
  i1558._clipFrom = i1559[42]
  i1558._clipTo = i1559[43]
  i1558.animClipFrom = i1559[44]
  i1558.animClipTo = i1559[45]
  return i1558
}

Deserializers["Dreamteck.Splines.SplineMesh+Channel"] = function (request, data, root) {
  var i1564 = root || request.c( 'Dreamteck.Splines.SplineMesh+Channel' )
  var i1565 = data
  i1564.name = i1565[0]
  i1564._iterationSeed = i1565[1]
  i1564._offsetSeed = i1565[2]
  i1564._rotationSeed = i1565[3]
  i1564._scaleSeed = i1565[4]
  request.r(i1565[5], i1565[6], 0, i1564, 'owner')
  var i1567 = i1565[7]
  var i1566 = new (System.Collections.Generic.List$1(Bridge.ns('Dreamteck.Splines.SplineMesh+Channel+MeshDefinition')))
  for(var i = 0; i < i1567.length; i += 1) {
    i1566.add(request.d('Dreamteck.Splines.SplineMesh+Channel+MeshDefinition', i1567[i + 0]));
  }
  i1564.meshes = i1566
  i1564._clipFrom = i1565[8]
  i1564._clipTo = i1565[9]
  i1564._randomOrder = !!i1565[10]
  i1564._overrideUVs = i1565[11]
  i1564._uvScale = new pc.Vec2( i1565[12], i1565[13] )
  i1564._uvOffset = new pc.Vec2( i1565[14], i1565[15] )
  i1564._overrideNormal = !!i1565[16]
  i1564._customNormal = new pc.Vec3( i1565[17], i1565[18], i1565[19] )
  i1564._type = i1565[20]
  i1564._count = i1565[21]
  i1564._autoCount = !!i1565[22]
  i1564._spacing = i1565[23]
  i1564._randomRotation = !!i1565[24]
  i1564._minRotation = new pc.Vec3( i1565[25], i1565[26], i1565[27] )
  i1564._maxRotation = new pc.Vec3( i1565[28], i1565[29], i1565[30] )
  i1564._randomOffset = !!i1565[31]
  i1564._minOffset = new pc.Vec2( i1565[32], i1565[33] )
  i1564._maxOffset = new pc.Vec2( i1565[34], i1565[35] )
  i1564._randomScale = !!i1565[36]
  i1564._uniformRandomScale = !!i1565[37]
  i1564._minScale = new pc.Vec3( i1565[38], i1565[39], i1565[40] )
  i1564._maxScale = new pc.Vec3( i1565[41], i1565[42], i1565[43] )
  i1564._overrideMaterialID = !!i1565[44]
  i1564._targetMaterialID = i1565[45]
  i1564._scaleModifier = request.d('Dreamteck.Splines.MeshScaleModifier', i1565[46], i1564._scaleModifier)
  return i1564
}

Deserializers["Dreamteck.Splines.SplineMesh+Channel+MeshDefinition"] = function (request, data, root) {
  var i1570 = root || request.c( 'Dreamteck.Splines.SplineMesh+Channel+MeshDefinition' )
  var i1571 = data
  var i1573 = i1571[0]
  var i1572 = []
  for(var i = 0; i < i1573.length; i += 3) {
    i1572.push( new pc.Vec3( i1573[i + 0], i1573[i + 1], i1573[i + 2] ) );
  }
  i1570.vertices = i1572
  var i1575 = i1571[1]
  var i1574 = []
  for(var i = 0; i < i1575.length; i += 3) {
    i1574.push( new pc.Vec3( i1575[i + 0], i1575[i + 1], i1575[i + 2] ) );
  }
  i1570.normals = i1574
  var i1577 = i1571[2]
  var i1576 = []
  for(var i = 0; i < i1577.length; i += 4) {
    i1576.push( new pc.Vec4( i1577[i + 0], i1577[i + 1], i1577[i + 2], i1577[i + 3] ) );
  }
  i1570.tangents = i1576
  var i1579 = i1571[3]
  var i1578 = []
  for(var i = 0; i < i1579.length; i += 4) {
    i1578.push( new pc.Color(i1579[i + 0], i1579[i + 1], i1579[i + 2], i1579[i + 3]) );
  }
  i1570.colors = i1578
  var i1581 = i1571[4]
  var i1580 = []
  for(var i = 0; i < i1581.length; i += 2) {
    i1580.push( new pc.Vec2( i1581[i + 0], i1581[i + 1] ) );
  }
  i1570.uv = i1580
  var i1583 = i1571[5]
  var i1582 = []
  for(var i = 0; i < i1583.length; i += 2) {
    i1582.push( new pc.Vec2( i1583[i + 0], i1583[i + 1] ) );
  }
  i1570.uv2 = i1582
  var i1585 = i1571[6]
  var i1584 = []
  for(var i = 0; i < i1585.length; i += 2) {
    i1584.push( new pc.Vec2( i1585[i + 0], i1585[i + 1] ) );
  }
  i1570.uv3 = i1584
  var i1587 = i1571[7]
  var i1586 = []
  for(var i = 0; i < i1587.length; i += 2) {
    i1586.push( new pc.Vec2( i1587[i + 0], i1587[i + 1] ) );
  }
  i1570.uv4 = i1586
  i1570.triangles = i1571[8]
  var i1589 = i1571[9]
  var i1588 = new (System.Collections.Generic.List$1(Bridge.ns('Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+Submesh')))
  for(var i = 0; i < i1589.length; i += 1) {
    i1588.add(request.d('Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+Submesh', i1589[i + 0]));
  }
  i1570.subMeshes = i1588
  i1570.bounds = request.d('Dreamteck.TS_Bounds', i1571[10], i1570.bounds)
  var i1591 = i1571[11]
  var i1590 = new (System.Collections.Generic.List$1(Bridge.ns('Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+VertexGroup')))
  for(var i = 0; i < i1591.length; i += 1) {
    i1590.add(request.d('Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+VertexGroup', i1591[i + 0]));
  }
  i1570.vertexGroups = i1590
  i1570._spacing = request.d('Dreamteck.Splines.SplineMesh+Channel+BoundsSpacing', i1571[12], i1570._spacing)
  request.r(i1571[13], i1571[14], 0, i1570, '_mesh')
  i1570._rotation = new pc.Vec3( i1571[15], i1571[16], i1571[17] )
  i1570._offset = new pc.Vec3( i1571[18], i1571[19], i1571[20] )
  i1570._scale = new pc.Vec3( i1571[21], i1571[22], i1571[23] )
  i1570._uvScale = new pc.Vec2( i1571[24], i1571[25] )
  i1570._uvOffset = new pc.Vec2( i1571[26], i1571[27] )
  i1570._uvRotation = i1571[28]
  i1570._mirror = i1571[29]
  i1570._vertexGroupingMargin = i1571[30]
  i1570._removeInnerFaces = !!i1571[31]
  i1570._flipFaces = !!i1571[32]
  i1570._doubleSided = !!i1571[33]
  return i1570
}

Deserializers["Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+Submesh"] = function (request, data, root) {
  var i1600 = root || request.c( 'Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+Submesh' )
  var i1601 = data
  i1600.triangles = i1601[0]
  return i1600
}

Deserializers["Dreamteck.TS_Bounds"] = function (request, data, root) {
  var i1602 = root || request.c( 'Dreamteck.TS_Bounds' )
  var i1603 = data
  i1602.center = new pc.Vec3( i1603[0], i1603[1], i1603[2] )
  i1602.extents = new pc.Vec3( i1603[3], i1603[4], i1603[5] )
  i1602.max = new pc.Vec3( i1603[6], i1603[7], i1603[8] )
  i1602.min = new pc.Vec3( i1603[9], i1603[10], i1603[11] )
  i1602.size = new pc.Vec3( i1603[12], i1603[13], i1603[14] )
  return i1602
}

Deserializers["Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+VertexGroup"] = function (request, data, root) {
  var i1606 = root || request.c( 'Dreamteck.Splines.SplineMesh+Channel+MeshDefinition+VertexGroup' )
  var i1607 = data
  i1606.value = i1607[0]
  i1606.percent = i1607[1]
  i1606.ids = i1607[2]
  return i1606
}

Deserializers["Dreamteck.Splines.SplineMesh+Channel+BoundsSpacing"] = function (request, data, root) {
  var i1608 = root || request.c( 'Dreamteck.Splines.SplineMesh+Channel+BoundsSpacing' )
  var i1609 = data
  i1608.front = i1609[0]
  i1608.back = i1609[1]
  return i1608
}

Deserializers["Dreamteck.Splines.MeshScaleModifier"] = function (request, data, root) {
  var i1610 = root || request.c( 'Dreamteck.Splines.MeshScaleModifier' )
  var i1611 = data
  var i1613 = i1611[0]
  var i1612 = new (System.Collections.Generic.List$1(Bridge.ns('Dreamteck.Splines.MeshScaleModifier+ScaleKey')))
  for(var i = 0; i < i1613.length; i += 1) {
    i1612.add(request.d('Dreamteck.Splines.MeshScaleModifier+ScaleKey', i1613[i + 0]));
  }
  i1610.keys = i1612
  i1610.blend = i1611[1]
  i1610.useClippedPercent = !!i1611[2]
  return i1610
}

Deserializers["Dreamteck.Splines.MeshScaleModifier+ScaleKey"] = function (request, data, root) {
  var i1616 = root || request.c( 'Dreamteck.Splines.MeshScaleModifier+ScaleKey' )
  var i1617 = data
  i1616.scale = new pc.Vec3( i1617[0], i1617[1], i1617[2] )
  i1616.interpolation = new pc.AnimationCurve( { keys_flow: i1617[3] } )
  i1616.blend = i1617[4]
  i1616._featherStart = i1617[5]
  i1616._featherEnd = i1617[6]
  i1616._centerStart = i1617[7]
  i1616._centerEnd = i1617[8]
  return i1616
}

Deserializers["Dreamteck.Splines.RotationModifier"] = function (request, data, root) {
  var i1618 = root || request.c( 'Dreamteck.Splines.RotationModifier' )
  var i1619 = data
  var i1621 = i1619[0]
  var i1620 = []
  for(var i = 0; i < i1621.length; i += 1) {
    i1620.push( request.d('Dreamteck.Splines.RotationModifier+RotationKey', i1621[i + 0]) );
  }
  i1618.keys = i1620
  i1618.blend = i1619[1]
  i1618.useClippedPercent = !!i1619[2]
  return i1618
}

Deserializers["Dreamteck.Splines.RotationModifier+RotationKey"] = function (request, data, root) {
  var i1624 = root || request.c( 'Dreamteck.Splines.RotationModifier+RotationKey' )
  var i1625 = data
  i1624.useLookTarget = !!i1625[0]
  request.r(i1625[1], i1625[2], 0, i1624, 'target')
  i1624.rotation = new pc.Vec3( i1625[3], i1625[4], i1625[5] )
  i1624.interpolation = new pc.AnimationCurve( { keys_flow: i1625[6] } )
  i1624.blend = i1625[7]
  i1624._featherStart = i1625[8]
  i1624._featherEnd = i1625[9]
  i1624._centerStart = i1625[10]
  i1624._centerEnd = i1625[11]
  return i1624
}

Deserializers["Dreamteck.Splines.OffsetModifier"] = function (request, data, root) {
  var i1626 = root || request.c( 'Dreamteck.Splines.OffsetModifier' )
  var i1627 = data
  var i1629 = i1627[0]
  var i1628 = []
  for(var i = 0; i < i1629.length; i += 1) {
    i1628.push( request.d('Dreamteck.Splines.OffsetModifier+OffsetKey', i1629[i + 0]) );
  }
  i1626.keys = i1628
  i1626.blend = i1627[1]
  i1626.useClippedPercent = !!i1627[2]
  return i1626
}

Deserializers["Dreamteck.Splines.OffsetModifier+OffsetKey"] = function (request, data, root) {
  var i1632 = root || request.c( 'Dreamteck.Splines.OffsetModifier+OffsetKey' )
  var i1633 = data
  i1632.offset = new pc.Vec2( i1633[0], i1633[1] )
  i1632.interpolation = new pc.AnimationCurve( { keys_flow: i1633[2] } )
  i1632.blend = i1633[3]
  i1632._featherStart = i1633[4]
  i1632._featherEnd = i1633[5]
  i1632._centerStart = i1633[6]
  i1632._centerEnd = i1633[7]
  return i1632
}

Deserializers["Dreamteck.Splines.ColorModifier"] = function (request, data, root) {
  var i1634 = root || request.c( 'Dreamteck.Splines.ColorModifier' )
  var i1635 = data
  var i1637 = i1635[0]
  var i1636 = []
  for(var i = 0; i < i1637.length; i += 1) {
    i1636.push( request.d('Dreamteck.Splines.ColorModifier+ColorKey', i1637[i + 0]) );
  }
  i1634.keys = i1636
  i1634.blend = i1635[1]
  i1634.useClippedPercent = !!i1635[2]
  return i1634
}

Deserializers["Dreamteck.Splines.ColorModifier+ColorKey"] = function (request, data, root) {
  var i1640 = root || request.c( 'Dreamteck.Splines.ColorModifier+ColorKey' )
  var i1641 = data
  i1640.color = new pc.Color(i1641[0], i1641[1], i1641[2], i1641[3])
  i1640.blendMode = i1641[4]
  i1640.interpolation = new pc.AnimationCurve( { keys_flow: i1641[5] } )
  i1640.blend = i1641[6]
  i1640._featherStart = i1641[7]
  i1640._featherEnd = i1641[8]
  i1640._centerStart = i1641[9]
  i1640._centerEnd = i1641[10]
  return i1640
}

Deserializers["Dreamteck.Splines.SizeModifier"] = function (request, data, root) {
  var i1642 = root || request.c( 'Dreamteck.Splines.SizeModifier' )
  var i1643 = data
  var i1645 = i1643[0]
  var i1644 = []
  for(var i = 0; i < i1645.length; i += 1) {
    i1644.push( request.d('Dreamteck.Splines.SizeModifier+SizeKey', i1645[i + 0]) );
  }
  i1642.keys = i1644
  i1642.blend = i1643[1]
  i1642.useClippedPercent = !!i1643[2]
  return i1642
}

Deserializers["Dreamteck.Splines.SizeModifier+SizeKey"] = function (request, data, root) {
  var i1648 = root || request.c( 'Dreamteck.Splines.SizeModifier+SizeKey' )
  var i1649 = data
  i1648.size = i1649[0]
  i1648.interpolation = new pc.AnimationCurve( { keys_flow: i1649[1] } )
  i1648.blend = i1649[2]
  i1648._featherStart = i1649[3]
  i1648._featherEnd = i1649[4]
  i1648._centerStart = i1649[5]
  i1648._centerEnd = i1649[6]
  return i1648
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.EdgeCollider2D"] = function (request, data, root) {
  var i1650 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.EdgeCollider2D' )
  var i1651 = data
  i1650.enabled = !!i1651[0]
  i1650.isTrigger = !!i1651[1]
  i1650.usedByEffector = !!i1651[2]
  i1650.density = i1651[3]
  i1650.offset = new pc.Vec2( i1651[4], i1651[5] )
  request.r(i1651[6], i1651[7], 0, i1650, 'material')
  i1650.edgeRadius = i1651[8]
  var i1653 = i1651[9]
  var i1652 = []
  for(var i = 0; i < i1653.length; i += 2) {
    i1652.push( new pc.Vec2( i1653[i + 0], i1653[i + 1] ) );
  }
  i1650.points = i1652
  i1650.useAdjacentStartPoint = !!i1651[10]
  i1650.adjacentStartPoint = new pc.Vec2( i1651[11], i1651[12] )
  i1650.useAdjacentEndPoint = !!i1651[13]
  i1650.adjacentEndPoint = new pc.Vec2( i1651[14], i1651[15] )
  return i1650
}

Deserializers["Dreamteck.Splines.EdgeColliderGenerator"] = function (request, data, root) {
  var i1654 = root || request.c( 'Dreamteck.Splines.EdgeColliderGenerator' )
  var i1655 = data
  i1654.updateRate = i1655[0]
  i1654.updateMethod = i1655[1]
  i1654.multithreaded = !!i1655[2]
  i1654.buildOnAwake = !!i1655[3]
  i1654.buildOnEnable = !!i1655[4]
  i1654._offset = i1655[5]
  request.r(i1655[6], i1655[7], 0, i1654, 'edgeCollider')
  var i1657 = i1655[8]
  var i1656 = []
  for(var i = 0; i < i1657.length; i += 2) {
    i1656.push( new pc.Vec2( i1657[i + 0], i1657[i + 1] ) );
  }
  i1654.vertices = i1656
  i1654._rotationModifier = request.d('Dreamteck.Splines.RotationModifier', i1655[9], i1654._rotationModifier)
  i1654._offsetModifier = request.d('Dreamteck.Splines.OffsetModifier', i1655[10], i1654._offsetModifier)
  i1654._colorModifier = request.d('Dreamteck.Splines.ColorModifier', i1655[11], i1654._colorModifier)
  i1654._sizeModifier = request.d('Dreamteck.Splines.SizeModifier', i1655[12], i1654._sizeModifier)
  request.r(i1655[13], i1655[14], 0, i1654, '_spline')
  i1654._autoUpdate = !!i1655[15]
  i1654._clipFromSample = request.d('Dreamteck.Splines.SplineSample', i1655[16], i1654._clipFromSample)
  i1654._clipToSample = request.d('Dreamteck.Splines.SplineSample', i1655[17], i1654._clipToSample)
  i1654._loopSamples = !!i1655[18]
  i1654._clipFrom = i1655[19]
  i1654._clipTo = i1655[20]
  i1654.animClipFrom = i1655[21]
  i1654.animClipTo = i1655[22]
  return i1654
}

Deserializers["PullingPin"] = function (request, data, root) {
  var i1658 = root || request.c( 'PullingPin' )
  var i1659 = data
  i1658.distanceMove = i1659[0]
  i1658.timeMove = i1659[1]
  var i1661 = i1659[2]
  var i1660 = new (System.Collections.Generic.List$1(Bridge.ns('Ball')))
  for(var i = 0; i < i1661.length; i += 2) {
  request.r(i1661[i + 0], i1661[i + 1], 1, i1660, '')
  }
  i1658.balls = i1660
  request.r(i1659[3], i1659[4], 0, i1658, 'tutorialHand')
  i1658.isFirstTutorial = !!i1659[5]
  request.r(i1659[6], i1659[7], 0, i1658, 'nextTutPin')
  i1658.length = i1659[8]
  request.r(i1659[9], i1659[10], 0, i1658, 'boxTrigger2D')
  request.r(i1659[11], i1659[12], 0, i1658, 'boxPhysics2D')
  request.r(i1659[13], i1659[14], 0, i1658, 'currentPinSkin')
  request.r(i1659[15], i1659[16], 0, i1658, 'skinHolder')
  i1658.pinState = i1659[17]
  return i1658
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Rigidbody2D"] = function (request, data, root) {
  var i1664 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Rigidbody2D' )
  var i1665 = data
  i1664.bodyType = i1665[0]
  request.r(i1665[1], i1665[2], 0, i1664, 'material')
  i1664.simulated = !!i1665[3]
  i1664.useAutoMass = !!i1665[4]
  i1664.mass = i1665[5]
  i1664.drag = i1665[6]
  i1664.angularDrag = i1665[7]
  i1664.gravityScale = i1665[8]
  i1664.collisionDetectionMode = i1665[9]
  i1664.sleepMode = i1665[10]
  i1664.constraints = i1665[11]
  return i1664
}

Deserializers["PinSkin"] = function (request, data, root) {
  var i1666 = root || request.c( 'PinSkin' )
  var i1667 = data
  i1666.PinID = i1667[0]
  request.r(i1667[1], i1667[2], 0, i1666, 'Pin_body')
  request.r(i1667[3], i1667[4], 0, i1666, 'Pin_tail')
  request.r(i1667[5], i1667[6], 0, i1666, 'Pin_archor_tail')
  request.r(i1667[7], i1667[8], 0, i1666, 'Pin_archor_left')
  request.r(i1667[9], i1667[10], 0, i1666, 'Pin_archor_right')
  return i1666
}

Deserializers["Ball"] = function (request, data, root) {
  var i1668 = root || request.c( 'Ball' )
  var i1669 = data
  i1668.BallType = i1669[0]
  request.r(i1669[1], i1669[2], 0, i1668, 'CurrentBallSkin')
  request.r(i1669[3], i1669[4], 0, i1668, 'KeyPin')
  request.r(i1669[5], i1669[6], 0, i1668, 'DefaultSkin')
  request.r(i1669[7], i1669[8], 0, i1668, 'SkinHolder')
  i1668.totalScore = i1669[9]
  request.r(i1669[10], i1669[11], 0, i1668, 'Rigidbody2D')
  i1668.IsUseMultipleVel = !!i1669[12]
  i1668.IsUseXAxis = !!i1669[13]
  i1668.IsUseYAxis = !!i1669[14]
  i1668.MultipleVel = i1669[15]
  i1668.MinIncreaseVel = i1669[16]
  request.r(i1669[17], i1669[18], 0, i1668, 'trailHolder')
  i1668.isHitRotateBrokenBall = !!i1669[19]
  i1668.isNumberedBallChild = !!i1669[20]
  i1668.isUnableToChangeColor = !!i1669[21]
  request.r(i1669[22], i1669[23], 0, i1668, 'isBridged')
  i1668.isAchieve = !!i1669[24]
  i1668.isActivated = !!i1669[25]
  i1668.type = i1669[26]
  return i1668
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.CircleCollider2D"] = function (request, data, root) {
  var i1670 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.CircleCollider2D' )
  var i1671 = data
  i1670.radius = i1671[0]
  i1670.enabled = !!i1671[1]
  i1670.isTrigger = !!i1671[2]
  i1670.usedByEffector = !!i1671[3]
  i1670.density = i1671[4]
  i1670.offset = new pc.Vec2( i1671[5], i1671[6] )
  request.r(i1671[7], i1671[8], 0, i1670, 'material')
  return i1670
}

Deserializers["BallSkin"] = function (request, data, root) {
  var i1672 = root || request.c( 'BallSkin' )
  var i1673 = data
  request.r(i1673[0], i1673[1], 0, i1672, 'MeshRenderer')
  var i1675 = i1673[2]
  var i1674 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Material')))
  for(var i = 0; i < i1675.length; i += 2) {
  request.r(i1675[i + 0], i1675[i + 1], 1, i1674, '')
  }
  i1672.DeactivatedMaterials = i1674
  var i1677 = i1673[3]
  var i1676 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.Material')))
  for(var i = 0; i < i1677.length; i += 2) {
  request.r(i1677[i + 0], i1677[i + 1], 1, i1676, '')
  }
  i1672.ActivatedMaterials = i1676
  return i1672
}

Deserializers["Spine.Unity.SkeletonAnimation"] = function (request, data, root) {
  var i1680 = root || request.c( 'Spine.Unity.SkeletonAnimation' )
  var i1681 = data
  i1680.loop = !!i1681[0]
  i1680.timeScale = i1681[1]
  request.r(i1681[2], i1681[3], 0, i1680, 'skeletonDataAsset')
  i1680.initialSkinName = i1681[4]
  i1680.fixPrefabOverrideViaMeshFilter = i1681[5]
  i1680.initialFlipX = !!i1681[6]
  i1680.initialFlipY = !!i1681[7]
  i1680.updateWhenInvisible = i1681[8]
  i1680.zSpacing = i1681[9]
  i1680.useClipping = !!i1681[10]
  i1680.immutableTriangles = !!i1681[11]
  i1680.pmaVertexColors = !!i1681[12]
  i1680.clearStateOnDisable = !!i1681[13]
  i1680.tintBlack = !!i1681[14]
  i1680.singleSubmesh = !!i1681[15]
  i1680.fixDrawOrder = !!i1681[16]
  i1680.addNormals = !!i1681[17]
  i1680.calculateTangents = !!i1681[18]
  i1680.maskInteraction = i1681[19]
  i1680.maskMaterials = request.d('Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials', i1681[20], i1680.maskMaterials)
  i1680.disableRenderingOnOverride = !!i1681[21]
  i1680._animationName = i1681[22]
  var i1683 = i1681[23]
  var i1682 = []
  for(var i = 0; i < i1683.length; i += 1) {
    i1682.push( i1683[i + 0] );
  }
  i1680.separatorSlotNames = i1682
  return i1680
}

Deserializers["Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials"] = function (request, data, root) {
  var i1684 = root || request.c( 'Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials' )
  var i1685 = data
  var i1687 = i1685[0]
  var i1686 = []
  for(var i = 0; i < i1687.length; i += 2) {
  request.r(i1687[i + 0], i1687[i + 1], 2, i1686, '')
  }
  i1684.materialsMaskDisabled = i1686
  var i1689 = i1685[1]
  var i1688 = []
  for(var i = 0; i < i1689.length; i += 2) {
  request.r(i1689[i + 0], i1689[i + 1], 2, i1688, '')
  }
  i1684.materialsInsideMask = i1688
  var i1691 = i1685[2]
  var i1690 = []
  for(var i = 0; i < i1691.length; i += 2) {
  request.r(i1691[i + 0], i1691[i + 1], 2, i1690, '')
  }
  i1684.materialsOutsideMask = i1690
  return i1684
}

Deserializers["TutorialGameObject"] = function (request, data, root) {
  var i1692 = root || request.c( 'TutorialGameObject' )
  var i1693 = data
  return i1692
}

Deserializers["LevelChallenge"] = function (request, data, root) {
  var i1694 = root || request.c( 'LevelChallenge' )
  var i1695 = data
  i1694.ScoreWin = i1695[0]
  i1694.cameraLayerMask = UnityEngine.LayerMask.FromIntegerValue( i1695[1] )
  i1694.isShowTutorialBg = !!i1695[2]
  i1694.BonusCoin = i1695[3]
  i1694.notificationType = i1695[4]
  i1694.iconType = i1695[5]
  request.r(i1695[6], i1695[7], 0, i1694, 'customImage')
  i1694.TotalScoreCanGet = i1695[8]
  i1694.InactiveBallsNumb = i1695[9]
  i1694.BallBreakNumb = i1695[10]
  i1694.BombExplodeNumb = i1695[11]
  i1694.PinDragNumb = i1695[12]
  i1694.isGetEventItem = !!i1695[13]
  i1694.numberMove = i1695[14]
  i1694.timeWaitResult = i1695[15]
  i1694.usingCustomIcon = !!i1695[16]
  i1694.currentScore = i1695[17]
  i1694.totalCoin = i1695[18]
  return i1694
}

Deserializers["OutsideZone2D"] = function (request, data, root) {
  var i1696 = root || request.c( 'OutsideZone2D' )
  var i1697 = data
  return i1696
}

Deserializers["OutsideZone3D"] = function (request, data, root) {
  var i1698 = root || request.c( 'OutsideZone3D' )
  var i1699 = data
  return i1698
}

Deserializers["CameraChallenge"] = function (request, data, root) {
  var i1700 = root || request.c( 'CameraChallenge' )
  var i1701 = data
  i1700.isMovable = !!i1701[0]
  i1700.vel = new pc.Vec3( i1701[1], i1701[2], i1701[3] )
  i1700.minTransformY = i1701[4]
  return i1700
}

Deserializers["Bomb"] = function (request, data, root) {
  var i1702 = root || request.c( 'Bomb' )
  var i1703 = data
  request.r(i1703[0], i1703[1], 0, i1702, 'SkinnedMeshRenderer')
  i1702.Force = i1703[2]
  i1702.Radius = i1703[3]
  i1702.IsHitBall = !!i1703[4]
  i1702.IsHitBallHolder = !!i1703[5]
  request.r(i1703[6], i1703[7], 0, i1702, 'Rigidbody2D')
  i1702.IsUseMultipleVel = !!i1703[8]
  i1702.IsUseXAxis = !!i1703[9]
  i1702.IsUseYAxis = !!i1703[10]
  i1702.MultipleVel = i1703[11]
  i1702.MinIncreaseVel = i1703[12]
  request.r(i1703[13], i1703[14], 0, i1702, 'centerPoint')
  request.r(i1703[15], i1703[16], 0, i1702, 'fireParticle')
  i1702.isExploded = !!i1703[17]
  request.r(i1703[18], i1703[19], 0, i1702, 'bombAnim')
  i1702.idle1 = i1703[20]
  i1702.idle2 = i1703[21]
  i1702.explosion = i1703[22]
  i1702.type = i1703[23]
  return i1702
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer"] = function (request, data, root) {
  var i1704 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer' )
  var i1705 = data
  i1704.enabled = !!i1705[0]
  request.r(i1705[1], i1705[2], 0, i1704, 'sharedMaterial')
  var i1707 = i1705[3]
  var i1706 = []
  for(var i = 0; i < i1707.length; i += 2) {
  request.r(i1707[i + 0], i1707[i + 1], 2, i1706, '')
  }
  i1704.sharedMaterials = i1706
  i1704.receiveShadows = !!i1705[4]
  i1704.shadowCastingMode = i1705[5]
  i1704.sortingLayerID = i1705[6]
  i1704.sortingOrder = i1705[7]
  i1704.lightmapIndex = i1705[8]
  i1704.lightmapSceneIndex = i1705[9]
  i1704.lightmapScaleOffset = new pc.Vec4( i1705[10], i1705[11], i1705[12], i1705[13] )
  i1704.lightProbeUsage = i1705[14]
  i1704.reflectionProbeUsage = i1705[15]
  request.r(i1705[16], i1705[17], 0, i1704, 'sharedMesh')
  var i1709 = i1705[18]
  var i1708 = []
  for(var i = 0; i < i1709.length; i += 2) {
  request.r(i1709[i + 0], i1709[i + 1], 2, i1708, '')
  }
  i1704.bones = i1708
  i1704.updateWhenOffscreen = !!i1705[19]
  i1704.localBounds = i1705[20]
  request.r(i1705[21], i1705[22], 0, i1704, 'rootBone')
  var i1711 = i1705[23]
  var i1710 = []
  for(var i = 0; i < i1711.length; i += 1) {
    i1710.push( request.d('Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer+BlendShapeWeight', i1711[i + 0]) );
  }
  i1704.blendShapesWeights = i1710
  return i1704
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer+BlendShapeWeight"] = function (request, data, root) {
  var i1716 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer+BlendShapeWeight' )
  var i1717 = data
  i1716.weight = i1717[0]
  return i1716
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Animator"] = function (request, data, root) {
  var i1718 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Animator' )
  var i1719 = data
  request.r(i1719[0], i1719[1], 0, i1718, 'animatorController')
  request.r(i1719[2], i1719[3], 0, i1718, 'avatar')
  i1718.updateMode = i1719[4]
  i1718.hasTransformHierarchy = !!i1719[5]
  i1718.applyRootMotion = !!i1719[6]
  var i1721 = i1719[7]
  var i1720 = []
  for(var i = 0; i < i1721.length; i += 2) {
  request.r(i1721[i + 0], i1721[i + 1], 2, i1720, '')
  }
  i1718.humanBones = i1720
  i1718.enabled = !!i1719[8]
  return i1718
}

Deserializers["BombHandle"] = function (request, data, root) {
  var i1722 = root || request.c( 'BombHandle' )
  var i1723 = data
  return i1722
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShapeFrame"] = function (request, data, root) {
  var i1726 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShapeFrame' )
  var i1727 = data
  i1726.weight = i1727[0]
  i1726.vertices = i1727[1]
  i1726.normals = i1727[2]
  i1726.tangents = i1727[3]
  return i1726
}

Deserializers["MultipleChallenge"] = function (request, data, root) {
  var i1728 = root || request.c( 'MultipleChallenge' )
  var i1729 = data
  i1728.ScoreWin = i1729[0]
  i1728.cameraLayerMask = UnityEngine.LayerMask.FromIntegerValue( i1729[1] )
  i1728.isShowTutorialBg = !!i1729[2]
  i1728.BonusCoin = i1729[3]
  i1728.notificationType = i1729[4]
  i1728.iconType = i1729[5]
  request.r(i1729[6], i1729[7], 0, i1728, 'customImage')
  i1728.TotalScoreCanGet = i1729[8]
  i1728.InactiveBallsNumb = i1729[9]
  i1728.BallBreakNumb = i1729[10]
  i1728.BombExplodeNumb = i1729[11]
  i1728.PinDragNumb = i1729[12]
  i1728.isGetEventItem = !!i1729[13]
  i1728.usingCustomIcon = !!i1729[14]
  i1728.currentScore = i1729[15]
  i1728.totalCoin = i1729[16]
  return i1728
}

Deserializers["PlusGate"] = function (request, data, root) {
  var i1730 = root || request.c( 'PlusGate' )
  var i1731 = data
  i1730.plusNumb = i1731[0]
  request.r(i1731[1], i1731[2], 0, i1730, 'plusText')
  var i1733 = i1731[3]
  var i1732 = new (System.Collections.Generic.List$1(Bridge.ns('ObjectCircle')))
  for(var i = 0; i < i1733.length; i += 2) {
  request.r(i1733[i + 0], i1733[i + 1], 1, i1732, '')
  }
  i1730._cacheTriggerBalls = i1732
  return i1730
}

Deserializers["MultipleGate"] = function (request, data, root) {
  var i1736 = root || request.c( 'MultipleGate' )
  var i1737 = data
  request.r(i1737[0], i1737[1], 0, i1736, 'MultiplyText')
  i1736.MultiplyNumb = i1737[2]
  var i1739 = i1737[3]
  var i1738 = new (System.Collections.Generic.List$1(Bridge.ns('ObjectCircle')))
  for(var i = 0; i < i1739.length; i += 2) {
  request.r(i1739[i + 0], i1739[i + 1], 1, i1738, '')
  }
  i1736._cacheTriggerBalls = i1738
  return i1736
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.TrailRenderer"] = function (request, data, root) {
  var i1740 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.TrailRenderer' )
  var i1741 = data
  i1740.enabled = !!i1741[0]
  request.r(i1741[1], i1741[2], 0, i1740, 'sharedMaterial')
  var i1743 = i1741[3]
  var i1742 = []
  for(var i = 0; i < i1743.length; i += 2) {
  request.r(i1743[i + 0], i1743[i + 1], 2, i1742, '')
  }
  i1740.sharedMaterials = i1742
  i1740.receiveShadows = !!i1741[4]
  i1740.shadowCastingMode = i1741[5]
  i1740.sortingLayerID = i1741[6]
  i1740.sortingOrder = i1741[7]
  i1740.lightmapIndex = i1741[8]
  i1740.lightmapSceneIndex = i1741[9]
  i1740.lightmapScaleOffset = new pc.Vec4( i1741[10], i1741[11], i1741[12], i1741[13] )
  i1740.lightProbeUsage = i1741[14]
  i1740.reflectionProbeUsage = i1741[15]
  var i1745 = i1741[16]
  var i1744 = []
  for(var i = 0; i < i1745.length; i += 3) {
    i1744.push( new pc.Vec3( i1745[i + 0], i1745[i + 1], i1745[i + 2] ) );
  }
  i1740.positions = i1744
  i1740.positionCount = i1741[17]
  i1740.time = i1741[18]
  i1740.startWidth = i1741[19]
  i1740.endWidth = i1741[20]
  i1740.widthMultiplier = i1741[21]
  i1740.autodestruct = !!i1741[22]
  i1740.emitting = !!i1741[23]
  i1740.numCornerVertices = i1741[24]
  i1740.numCapVertices = i1741[25]
  i1740.minVertexDistance = i1741[26]
  i1740.colorGradient = i1741[27] ? new pc.ColorGradient(i1741[27][0], i1741[27][1], i1741[27][2]) : null
  i1740.startColor = new pc.Color(i1741[28], i1741[29], i1741[30], i1741[31])
  i1740.endColor = new pc.Color(i1741[32], i1741[33], i1741[34], i1741[35])
  i1740.generateLightingData = !!i1741[36]
  i1740.textureMode = i1741[37]
  i1740.alignment = i1741[38]
  i1740.widthCurve = new pc.AnimationCurve( { keys_flow: i1741[39] } )
  return i1740
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.Light"] = function (request, data, root) {
  var i1746 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.Light' )
  var i1747 = data
  i1746.enabled = !!i1747[0]
  i1746.type = i1747[1]
  i1746.color = new pc.Color(i1747[2], i1747[3], i1747[4], i1747[5])
  i1746.cullingMask = i1747[6]
  i1746.intensity = i1747[7]
  i1746.range = i1747[8]
  i1746.spotAngle = i1747[9]
  i1746.shadows = i1747[10]
  i1746.shadowNormalBias = i1747[11]
  i1746.shadowBias = i1747[12]
  i1746.shadowStrength = i1747[13]
  i1746.shadowResolution = i1747[14]
  i1746.lightmapBakeType = i1747[15]
  i1746.renderMode = i1747[16]
  request.r(i1747[17], i1747[18], 0, i1746, 'cookie')
  i1746.cookieSize = i1747[19]
  return i1746
}

Deserializers["UnityEngine.EventSystems.EventSystem"] = function (request, data, root) {
  var i1748 = root || request.c( 'UnityEngine.EventSystems.EventSystem' )
  var i1749 = data
  request.r(i1749[0], i1749[1], 0, i1748, 'm_FirstSelected')
  i1748.m_sendNavigationEvents = !!i1749[2]
  i1748.m_DragThreshold = i1749[3]
  return i1748
}

Deserializers["UnityEngine.InputSystem.UI.InputSystemUIInputModule"] = function (request, data, root) {
  var i1750 = root || request.c( 'UnityEngine.InputSystem.UI.InputSystemUIInputModule' )
  var i1751 = data
  i1750.m_MoveRepeatDelay = i1751[0]
  i1750.m_MoveRepeatRate = i1751[1]
  request.r(i1751[2], i1751[3], 0, i1750, 'm_XRTrackingOrigin')
  request.r(i1751[4], i1751[5], 0, i1750, 'm_ActionsAsset')
  request.r(i1751[6], i1751[7], 0, i1750, 'm_PointAction')
  request.r(i1751[8], i1751[9], 0, i1750, 'm_MoveAction')
  request.r(i1751[10], i1751[11], 0, i1750, 'm_SubmitAction')
  request.r(i1751[12], i1751[13], 0, i1750, 'm_CancelAction')
  request.r(i1751[14], i1751[15], 0, i1750, 'm_LeftClickAction')
  request.r(i1751[16], i1751[17], 0, i1750, 'm_MiddleClickAction')
  request.r(i1751[18], i1751[19], 0, i1750, 'm_RightClickAction')
  request.r(i1751[20], i1751[21], 0, i1750, 'm_ScrollWheelAction')
  request.r(i1751[22], i1751[23], 0, i1750, 'm_TrackedDevicePositionAction')
  request.r(i1751[24], i1751[25], 0, i1750, 'm_TrackedDeviceOrientationAction')
  i1750.m_DeselectOnBackgroundClick = !!i1751[26]
  i1750.m_PointerBehavior = i1751[27]
  i1750.m_CursorLockBehavior = i1751[28]
  i1750.m_SendPointerHoverToParent = !!i1751[29]
  return i1750
}

Deserializers["GameManager"] = function (request, data, root) {
  var i1752 = root || request.c( 'GameManager' )
  var i1753 = data
  request.r(i1753[0], i1753[1], 0, i1752, 'LevelController')
  i1752.GameState = i1753[2]
  var i1755 = i1753[3]
  var i1754 = new (System.Collections.Generic.List$1(Bridge.ns('Level')))
  for(var i = 0; i < i1755.length; i += 2) {
  request.r(i1755[i + 0], i1755[i + 1], 1, i1754, '')
  }
  i1752._levelList = i1754
  return i1752
}

Deserializers["LevelController"] = function (request, data, root) {
  var i1758 = root || request.c( 'LevelController' )
  var i1759 = data
  request.r(i1759[0], i1759[1], 0, i1758, 'iconDataConfig')
  i1758.LevelType = i1759[2]
  request.r(i1759[3], i1759[4], 0, i1758, 'CurrentLevel')
  i1758.LevelLoadingType = i1759[5]
  return i1758
}

Deserializers["Lean.Touch.LeanTouch"] = function (request, data, root) {
  var i1760 = root || request.c( 'Lean.Touch.LeanTouch' )
  var i1761 = data
  i1760.tapThreshold = i1761[0]
  i1760.swipeThreshold = i1761[1]
  i1760.referenceDpi = i1761[2]
  i1760.guiLayers = UnityEngine.LayerMask.FromIntegerValue( i1761[3] )
  i1760.useTouch = !!i1761[4]
  i1760.useHover = !!i1761[5]
  i1760.useMouse = !!i1761[6]
  i1760.useSimulator = !!i1761[7]
  i1760.disableMouseEmulation = !!i1761[8]
  i1760.recordFingers = !!i1761[9]
  i1760.recordThreshold = i1761[10]
  i1760.recordLimit = i1761[11]
  return i1760
}

Deserializers["PopupController"] = function (request, data, root) {
  var i1762 = root || request.c( 'PopupController' )
  var i1763 = data
  request.r(i1763[0], i1763[1], 0, i1762, 'CanvasTransform')
  request.r(i1763[2], i1763[3], 0, i1762, 'CanvasScaler')
  var i1765 = i1763[4]
  var i1764 = new (System.Collections.Generic.List$1(Bridge.ns('Popup')))
  for(var i = 0; i < i1765.length; i += 2) {
  request.r(i1765[i + 0], i1765[i + 1], 1, i1764, '')
  }
  i1762.Popups = i1764
  return i1762
}

Deserializers["SoundController"] = function (request, data, root) {
  var i1768 = root || request.c( 'SoundController' )
  var i1769 = data
  request.r(i1769[0], i1769[1], 0, i1768, 'BackgroundAudio')
  request.r(i1769[2], i1769[3], 0, i1768, 'FxAudio')
  var i1771 = i1769[4]
  var i1770 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.AudioClip')))
  for(var i = 0; i < i1771.length; i += 2) {
  request.r(i1771[i + 0], i1771[i + 1], 1, i1770, '')
  }
  i1768.AudioClips = i1770
  i1768.delayTimeStack = i1769[5]
  i1768.delayTimeLava = i1769[6]
  i1768.delayTimePortal = i1769[7]
  i1768.delayTimeCoin = i1769[8]
  i1768.delayBallInBallHolder = i1769[9]
  return i1768
}

Deserializers["Pancake.Notification.GameNotificationsManager"] = function (request, data, root) {
  var i1774 = root || request.c( 'Pancake.Notification.GameNotificationsManager' )
  var i1775 = data
  i1774.mode = i1775[0]
  i1774.autoBadging = !!i1775[1]
  return i1774
}

Deserializers["Pancake.Notification.NotificationConsole"] = function (request, data, root) {
  var i1776 = root || request.c( 'Pancake.Notification.NotificationConsole' )
  var i1777 = data
  i1776.onUpdateDeliveryTime = request.d('UnityEngine.Events.UnityEvent', i1777[0], i1776.onUpdateDeliveryTime)
  var i1779 = i1777[1]
  var i1778 = []
  for(var i = 0; i < i1779.length; i += 1) {
    i1778.push( request.d('Pancake.Notification.NotificationStructureData', i1779[i + 0]) );
  }
  i1776.structures = i1778
  return i1776
}

Deserializers["Pancake.Notification.NotificationStructureData"] = function (request, data, root) {
  var i1782 = root || request.c( 'Pancake.Notification.NotificationStructureData' )
  var i1783 = data
  i1782.type = i1783[0]
  i1782.chanel = i1783[1]
  i1782.minute = i1783[2]
  i1782.autoSchedule = !!i1783[3]
  var i1785 = i1783[4]
  var i1784 = []
  for(var i = 0; i < i1785.length; i += 1) {
    i1784.push( request.d('Pancake.Notification.NotificationData', i1785[i + 0]) );
  }
  i1782.datas = i1784
  return i1782
}

Deserializers["Pancake.Notification.NotificationData"] = function (request, data, root) {
  var i1788 = root || request.c( 'Pancake.Notification.NotificationData' )
  var i1789 = data
  i1788.title = i1789[0]
  i1788.message = i1789[1]
  return i1788
}

Deserializers["ConfigController"] = function (request, data, root) {
  var i1790 = root || request.c( 'ConfigController' )
  var i1791 = data
  request.r(i1791[0], i1791[1], 0, i1790, 'gameConfig')
  request.r(i1791[2], i1791[3], 0, i1790, 'soundConfig')
  request.r(i1791[4], i1791[5], 0, i1790, 'itemConfig')
  request.r(i1791[6], i1791[7], 0, i1790, 'challengeConfig')
  request.r(i1791[8], i1791[9], 0, i1790, 'gameEventConfig')
  return i1790
}

Deserializers["Luna.Unity.DTO.UnityEngine.Components.AudioSource"] = function (request, data, root) {
  var i1792 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Components.AudioSource' )
  var i1793 = data
  request.r(i1793[0], i1793[1], 0, i1792, 'clip')
  request.r(i1793[2], i1793[3], 0, i1792, 'outputAudioMixerGroup')
  i1792.playOnAwake = !!i1793[4]
  i1792.loop = !!i1793[5]
  i1792.time = i1793[6]
  i1792.volume = i1793[7]
  i1792.pitch = i1793[8]
  i1792.enabled = !!i1793[9]
  return i1792
}

Deserializers["CameraUIController"] = function (request, data, root) {
  var i1794 = root || request.c( 'CameraUIController' )
  var i1795 = data
  request.r(i1795[0], i1795[1], 0, i1794, 'Camera')
  return i1794
}

Deserializers["VFXSpawnController"] = function (request, data, root) {
  var i1796 = root || request.c( 'VFXSpawnController' )
  var i1797 = data
  var i1799 = i1797[0]
  var i1798 = new (System.Collections.Generic.List$1(Bridge.ns('VisualEffectData')))
  for(var i = 0; i < i1799.length; i += 1) {
    i1798.add(request.d('VisualEffectData', i1799[i + 0]));
  }
  i1796.visualEffectData = i1798
  return i1796
}

Deserializers["VisualEffectData"] = function (request, data, root) {
  var i1802 = root || request.c( 'VisualEffectData' )
  var i1803 = data
  var i1805 = i1803[0]
  var i1804 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.GameObject')))
  for(var i = 0; i < i1805.length; i += 2) {
  request.r(i1805[i + 0], i1805[i + 1], 1, i1804, '')
  }
  i1802.EffectList = i1804
  i1802.VisualEffectType = i1803[1]
  return i1802
}

Deserializers["LoadingController"] = function (request, data, root) {
  var i1808 = root || request.c( 'LoadingController' )
  var i1809 = data
  i1808.timeLoading = i1809[0]
  request.r(i1809[1], i1809[2], 0, i1808, 'progressBar')
  request.r(i1809[3], i1809[4], 0, i1808, 'loadingText')
  return i1808
}

Deserializers["OdeeoManager"] = function (request, data, root) {
  var i1810 = root || request.c( 'OdeeoManager' )
  var i1811 = data
  i1810.logLevel = i1811[0]
  return i1810
}

Deserializers["AdjustController"] = function (request, data, root) {
  var i1812 = root || request.c( 'AdjustController' )
  var i1813 = data
  return i1812
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.PhysicsMaterial2D"] = function (request, data, root) {
  var i1814 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.PhysicsMaterial2D' )
  var i1815 = data
  i1814.name = i1815[0]
  i1814.bounciness = i1815[1]
  i1814.friction = i1815[2]
  return i1814
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader"] = function (request, data, root) {
  var i1816 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader' )
  var i1817 = data
  var i1819 = i1817[0]
  var i1818 = new (System.Collections.Generic.List$1(Bridge.ns('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError')))
  for(var i = 0; i < i1819.length; i += 1) {
    i1818.add(request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError', i1819[i + 0]));
  }
  i1816.ShaderCompilationErrors = i1818
  i1816.name = i1817[1]
  i1816.guid = i1817[2]
  var i1821 = i1817[3]
  var i1820 = []
  for(var i = 0; i < i1821.length; i += 1) {
    i1820.push( i1821[i + 0] );
  }
  i1816.shaderDefinedKeywords = i1820
  var i1823 = i1817[4]
  var i1822 = []
  for(var i = 0; i < i1823.length; i += 1) {
    i1822.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass', i1823[i + 0]) );
  }
  i1816.passes = i1822
  var i1825 = i1817[5]
  var i1824 = []
  for(var i = 0; i < i1825.length; i += 1) {
    i1824.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass', i1825[i + 0]) );
  }
  i1816.usePasses = i1824
  var i1827 = i1817[6]
  var i1826 = []
  for(var i = 0; i < i1827.length; i += 1) {
    i1826.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue', i1827[i + 0]) );
  }
  i1816.defaultParameterValues = i1826
  request.r(i1817[7], i1817[8], 0, i1816, 'unityFallbackShader')
  i1816.readDepth = !!i1817[9]
  i1816.isCreatedByShaderGraph = !!i1817[10]
  i1816.compiled = !!i1817[11]
  return i1816
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError"] = function (request, data, root) {
  var i1830 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError' )
  var i1831 = data
  i1830.shaderName = i1831[0]
  i1830.errorMessage = i1831[1]
  return i1830
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass"] = function (request, data, root) {
  var i1834 = root || new pc.UnityShaderPass()
  var i1835 = data
  i1834.id = i1835[0]
  i1834.subShaderIndex = i1835[1]
  i1834.name = i1835[2]
  i1834.passType = i1835[3]
  i1834.grabPassTextureName = i1835[4]
  i1834.usePass = !!i1835[5]
  i1834.zTest = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[6], i1834.zTest)
  i1834.zWrite = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[7], i1834.zWrite)
  i1834.culling = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[8], i1834.culling)
  i1834.blending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i1835[9], i1834.blending)
  i1834.alphaBlending = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending', i1835[10], i1834.alphaBlending)
  i1834.colorWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[11], i1834.colorWriteMask)
  i1834.offsetUnits = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[12], i1834.offsetUnits)
  i1834.offsetFactor = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[13], i1834.offsetFactor)
  i1834.stencilRef = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[14], i1834.stencilRef)
  i1834.stencilReadMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[15], i1834.stencilReadMask)
  i1834.stencilWriteMask = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1835[16], i1834.stencilWriteMask)
  i1834.stencilOp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i1835[17], i1834.stencilOp)
  i1834.stencilOpFront = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i1835[18], i1834.stencilOpFront)
  i1834.stencilOpBack = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp', i1835[19], i1834.stencilOpBack)
  var i1837 = i1835[20]
  var i1836 = []
  for(var i = 0; i < i1837.length; i += 1) {
    i1836.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag', i1837[i + 0]) );
  }
  i1834.tags = i1836
  var i1839 = i1835[21]
  var i1838 = []
  for(var i = 0; i < i1839.length; i += 1) {
    i1838.push( i1839[i + 0] );
  }
  i1834.passDefinedKeywords = i1838
  var i1841 = i1835[22]
  var i1840 = []
  for(var i = 0; i < i1841.length; i += 1) {
    i1840.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup', i1841[i + 0]) );
  }
  i1834.passDefinedKeywordGroups = i1840
  var i1843 = i1835[23]
  var i1842 = []
  for(var i = 0; i < i1843.length; i += 1) {
    i1842.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i1843[i + 0]) );
  }
  i1834.variants = i1842
  var i1845 = i1835[24]
  var i1844 = []
  for(var i = 0; i < i1845.length; i += 1) {
    i1844.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant', i1845[i + 0]) );
  }
  i1834.excludedVariants = i1844
  i1834.hasDepthReader = !!i1835[25]
  return i1834
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value"] = function (request, data, root) {
  var i1846 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value' )
  var i1847 = data
  i1846.val = i1847[0]
  i1846.name = i1847[1]
  return i1846
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending"] = function (request, data, root) {
  var i1848 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending' )
  var i1849 = data
  i1848.src = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1849[0], i1848.src)
  i1848.dst = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1849[1], i1848.dst)
  i1848.op = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1849[2], i1848.op)
  return i1848
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp"] = function (request, data, root) {
  var i1850 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp' )
  var i1851 = data
  i1850.pass = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1851[0], i1850.pass)
  i1850.fail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1851[1], i1850.fail)
  i1850.zFail = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1851[2], i1850.zFail)
  i1850.comp = request.d('Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value', i1851[3], i1850.comp)
  return i1850
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag"] = function (request, data, root) {
  var i1854 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag' )
  var i1855 = data
  i1854.name = i1855[0]
  i1854.value = i1855[1]
  return i1854
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup"] = function (request, data, root) {
  var i1858 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup' )
  var i1859 = data
  var i1861 = i1859[0]
  var i1860 = []
  for(var i = 0; i < i1861.length; i += 1) {
    i1860.push( i1861[i + 0] );
  }
  i1858.keywords = i1860
  i1858.hasDiscard = !!i1859[1]
  return i1858
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant"] = function (request, data, root) {
  var i1864 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant' )
  var i1865 = data
  i1864.passId = i1865[0]
  i1864.subShaderIndex = i1865[1]
  var i1867 = i1865[2]
  var i1866 = []
  for(var i = 0; i < i1867.length; i += 1) {
    i1866.push( i1867[i + 0] );
  }
  i1864.keywords = i1866
  i1864.vertexProgram = i1865[3]
  i1864.fragmentProgram = i1865[4]
  i1864.exportedForWebGl2 = !!i1865[5]
  i1864.readDepth = !!i1865[6]
  return i1864
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass"] = function (request, data, root) {
  var i1870 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass' )
  var i1871 = data
  request.r(i1871[0], i1871[1], 0, i1870, 'shader')
  i1870.pass = i1871[2]
  return i1870
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue"] = function (request, data, root) {
  var i1874 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue' )
  var i1875 = data
  i1874.name = i1875[0]
  i1874.type = i1875[1]
  i1874.value = new pc.Vec4( i1875[2], i1875[3], i1875[4], i1875[5] )
  i1874.textureValue = i1875[6]
  i1874.shaderPropertyFlag = i1875[7]
  return i1874
}

Deserializers["Luna.Unity.DTO.UnityEngine.Textures.Sprite"] = function (request, data, root) {
  var i1876 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Textures.Sprite' )
  var i1877 = data
  i1876.name = i1877[0]
  request.r(i1877[1], i1877[2], 0, i1876, 'texture')
  i1876.aabb = i1877[3]
  i1876.vertices = i1877[4]
  i1876.triangles = i1877[5]
  i1876.textureRect = UnityEngine.Rect.MinMaxRect(i1877[6], i1877[7], i1877[8], i1877[9])
  i1876.packedRect = UnityEngine.Rect.MinMaxRect(i1877[10], i1877[11], i1877[12], i1877[13])
  i1876.border = new pc.Vec4( i1877[14], i1877[15], i1877[16], i1877[17] )
  i1876.transparency = i1877[18]
  i1876.bounds = i1877[19]
  i1876.pixelsPerUnit = i1877[20]
  i1876.textureWidth = i1877[21]
  i1876.textureHeight = i1877[22]
  i1876.nativeSize = new pc.Vec2( i1877[23], i1877[24] )
  i1876.pivot = new pc.Vec2( i1877[25], i1877[26] )
  i1876.textureRectOffset = new pc.Vec2( i1877[27], i1877[28] )
  return i1876
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.AudioClip"] = function (request, data, root) {
  var i1878 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.AudioClip' )
  var i1879 = data
  i1878.name = i1879[0]
  return i1878
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip"] = function (request, data, root) {
  var i1880 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip' )
  var i1881 = data
  i1880.name = i1881[0]
  i1880.wrapMode = i1881[1]
  i1880.isLooping = !!i1881[2]
  i1880.length = i1881[3]
  var i1883 = i1881[4]
  var i1882 = []
  for(var i = 0; i < i1883.length; i += 1) {
    i1882.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve', i1883[i + 0]) );
  }
  i1880.curves = i1882
  var i1885 = i1881[5]
  var i1884 = []
  for(var i = 0; i < i1885.length; i += 1) {
    i1884.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent', i1885[i + 0]) );
  }
  i1880.events = i1884
  i1880.halfPrecision = !!i1881[6]
  i1880._frameRate = i1881[7]
  i1880.localBounds = request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds', i1881[8], i1880.localBounds)
  i1880.hasMuscleCurves = !!i1881[9]
  var i1887 = i1881[10]
  var i1886 = []
  for(var i = 0; i < i1887.length; i += 1) {
    i1886.push( i1887[i + 0] );
  }
  i1880.clipMuscleConstant = i1886
  i1880.clipBindingConstant = request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant', i1881[11], i1880.clipBindingConstant)
  return i1880
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve"] = function (request, data, root) {
  var i1890 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve' )
  var i1891 = data
  i1890.path = i1891[0]
  i1890.hash = i1891[1]
  i1890.componentType = i1891[2]
  i1890.property = i1891[3]
  i1890.keys = i1891[4]
  var i1893 = i1891[5]
  var i1892 = []
  for(var i = 0; i < i1893.length; i += 1) {
    i1892.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey', i1893[i + 0]) );
  }
  i1890.objectReferenceKeys = i1892
  return i1890
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey"] = function (request, data, root) {
  var i1896 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey' )
  var i1897 = data
  i1896.time = i1897[0]
  request.r(i1897[1], i1897[2], 0, i1896, 'value')
  return i1896
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent"] = function (request, data, root) {
  var i1900 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent' )
  var i1901 = data
  i1900.functionName = i1901[0]
  i1900.floatParameter = i1901[1]
  i1900.intParameter = i1901[2]
  i1900.stringParameter = i1901[3]
  request.r(i1901[4], i1901[5], 0, i1900, 'objectReferenceParameter')
  i1900.time = i1901[6]
  return i1900
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds"] = function (request, data, root) {
  var i1902 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds' )
  var i1903 = data
  i1902.center = new pc.Vec3( i1903[0], i1903[1], i1903[2] )
  i1902.extends = new pc.Vec3( i1903[3], i1903[4], i1903[5] )
  return i1902
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant"] = function (request, data, root) {
  var i1906 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant' )
  var i1907 = data
  var i1909 = i1907[0]
  var i1908 = []
  for(var i = 0; i < i1909.length; i += 1) {
    i1908.push( i1909[i + 0] );
  }
  i1906.genericBindings = i1908
  var i1911 = i1907[1]
  var i1910 = []
  for(var i = 0; i < i1911.length; i += 1) {
    i1910.push( i1911[i + 0] );
  }
  i1906.pptrCurveMapping = i1910
  return i1906
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font"] = function (request, data, root) {
  var i1912 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font' )
  var i1913 = data
  i1912.name = i1913[0]
  i1912.ascent = i1913[1]
  i1912.originalLineHeight = i1913[2]
  i1912.fontSize = i1913[3]
  var i1915 = i1913[4]
  var i1914 = []
  for(var i = 0; i < i1915.length; i += 1) {
    i1914.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo', i1915[i + 0]) );
  }
  i1912.characterInfo = i1914
  request.r(i1913[5], i1913[6], 0, i1912, 'texture')
  i1912.originalFontSize = i1913[7]
  return i1912
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo"] = function (request, data, root) {
  var i1918 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo' )
  var i1919 = data
  i1918.index = i1919[0]
  i1918.advance = i1919[1]
  i1918.bearing = i1919[2]
  i1918.glyphWidth = i1919[3]
  i1918.glyphHeight = i1919[4]
  i1918.minX = i1919[5]
  i1918.maxX = i1919[6]
  i1918.minY = i1919[7]
  i1918.maxY = i1919[8]
  i1918.uvBottomLeftX = i1919[9]
  i1918.uvBottomLeftY = i1919[10]
  i1918.uvBottomRightX = i1919[11]
  i1918.uvBottomRightY = i1919[12]
  i1918.uvTopLeftX = i1919[13]
  i1918.uvTopLeftY = i1919[14]
  i1918.uvTopRightX = i1919[15]
  i1918.uvTopRightY = i1919[16]
  return i1918
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorController"] = function (request, data, root) {
  var i1920 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorController' )
  var i1921 = data
  i1920.name = i1921[0]
  var i1923 = i1921[1]
  var i1922 = []
  for(var i = 0; i < i1923.length; i += 1) {
    i1922.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer', i1923[i + 0]) );
  }
  i1920.layers = i1922
  var i1925 = i1921[2]
  var i1924 = []
  for(var i = 0; i < i1925.length; i += 1) {
    i1924.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter', i1925[i + 0]) );
  }
  i1920.parameters = i1924
  i1920.animationClips = i1921[3]
  i1920.avatarUnsupported = i1921[4]
  return i1920
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer"] = function (request, data, root) {
  var i1928 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer' )
  var i1929 = data
  i1928.name = i1929[0]
  i1928.defaultWeight = i1929[1]
  i1928.blendingMode = i1929[2]
  i1928.avatarMask = i1929[3]
  i1928.syncedLayerIndex = i1929[4]
  i1928.syncedLayerAffectsTiming = !!i1929[5]
  i1928.syncedLayers = i1929[6]
  i1928.stateMachine = request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine', i1929[7], i1928.stateMachine)
  return i1928
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine"] = function (request, data, root) {
  var i1930 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine' )
  var i1931 = data
  i1930.id = i1931[0]
  i1930.name = i1931[1]
  i1930.path = i1931[2]
  var i1933 = i1931[3]
  var i1932 = []
  for(var i = 0; i < i1933.length; i += 1) {
    i1932.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState', i1933[i + 0]) );
  }
  i1930.states = i1932
  var i1935 = i1931[4]
  var i1934 = []
  for(var i = 0; i < i1935.length; i += 1) {
    i1934.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine', i1935[i + 0]) );
  }
  i1930.machines = i1934
  var i1937 = i1931[5]
  var i1936 = []
  for(var i = 0; i < i1937.length; i += 1) {
    i1936.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition', i1937[i + 0]) );
  }
  i1930.entryStateTransitions = i1936
  var i1939 = i1931[6]
  var i1938 = []
  for(var i = 0; i < i1939.length; i += 1) {
    i1938.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition', i1939[i + 0]) );
  }
  i1930.exitStateTransitions = i1938
  var i1941 = i1931[7]
  var i1940 = []
  for(var i = 0; i < i1941.length; i += 1) {
    i1940.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition', i1941[i + 0]) );
  }
  i1930.anyStateTransitions = i1940
  i1930.defaultStateId = i1931[8]
  return i1930
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState"] = function (request, data, root) {
  var i1944 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState' )
  var i1945 = data
  i1944.id = i1945[0]
  i1944.name = i1945[1]
  i1944.cycleOffset = i1945[2]
  i1944.cycleOffsetParameter = i1945[3]
  i1944.cycleOffsetParameterActive = !!i1945[4]
  i1944.mirror = !!i1945[5]
  i1944.mirrorParameter = i1945[6]
  i1944.mirrorParameterActive = !!i1945[7]
  i1944.motionId = i1945[8]
  i1944.nameHash = i1945[9]
  i1944.fullPathHash = i1945[10]
  i1944.speed = i1945[11]
  i1944.speedParameter = i1945[12]
  i1944.speedParameterActive = !!i1945[13]
  i1944.tag = i1945[14]
  i1944.tagHash = i1945[15]
  i1944.writeDefaultValues = !!i1945[16]
  var i1947 = i1945[17]
  var i1946 = []
  for(var i = 0; i < i1947.length; i += 2) {
  request.r(i1947[i + 0], i1947[i + 1], 2, i1946, '')
  }
  i1944.behaviours = i1946
  var i1949 = i1945[18]
  var i1948 = []
  for(var i = 0; i < i1949.length; i += 1) {
    i1948.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition', i1949[i + 0]) );
  }
  i1944.transitions = i1948
  return i1944
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition"] = function (request, data, root) {
  var i1954 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition' )
  var i1955 = data
  i1954.destinationStateId = i1955[0]
  i1954.isExit = !!i1955[1]
  i1954.mute = !!i1955[2]
  i1954.solo = !!i1955[3]
  var i1957 = i1955[4]
  var i1956 = []
  for(var i = 0; i < i1957.length; i += 1) {
    i1956.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition', i1957[i + 0]) );
  }
  i1954.conditions = i1956
  return i1954
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition"] = function (request, data, root) {
  var i1960 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition' )
  var i1961 = data
  i1960.fullPath = i1961[0]
  i1960.canTransitionToSelf = !!i1961[1]
  i1960.duration = i1961[2]
  i1960.exitTime = i1961[3]
  i1960.hasExitTime = !!i1961[4]
  i1960.hasFixedDuration = !!i1961[5]
  i1960.interruptionSource = i1961[6]
  i1960.offset = i1961[7]
  i1960.orderedInterruption = !!i1961[8]
  i1960.destinationStateId = i1961[9]
  i1960.isExit = !!i1961[10]
  i1960.mute = !!i1961[11]
  i1960.solo = !!i1961[12]
  var i1963 = i1961[13]
  var i1962 = []
  for(var i = 0; i < i1963.length; i += 1) {
    i1962.push( request.d('Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition', i1963[i + 0]) );
  }
  i1960.conditions = i1962
  return i1960
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter"] = function (request, data, root) {
  var i1966 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter' )
  var i1967 = data
  i1966.defaultBool = !!i1967[0]
  i1966.defaultFloat = i1967[1]
  i1966.defaultInt = i1967[2]
  i1966.name = i1967[3]
  i1966.nameHash = i1967[4]
  i1966.type = i1967[5]
  return i1966
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.TextAsset"] = function (request, data, root) {
  var i1970 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.TextAsset' )
  var i1971 = data
  i1970.name = i1971[0]
  i1970.bytes64 = i1971[1]
  i1970.data = i1971[2]
  return i1970
}

Deserializers["UnityEngine.InputSystem.InputActionAsset"] = function (request, data, root) {
  var i1972 = root || request.c( 'UnityEngine.InputSystem.InputActionAsset' )
  var i1973 = data
  var i1975 = i1973[0]
  var i1974 = []
  for(var i = 0; i < i1975.length; i += 1) {
    i1974.push( request.d('UnityEngine.InputSystem.InputActionMap', i1975[i + 0]) );
  }
  i1972.m_ActionMaps = i1974
  var i1977 = i1973[1]
  var i1976 = []
  for(var i = 0; i < i1977.length; i += 1) {
    i1976.push( request.d('UnityEngine.InputSystem.InputControlScheme', i1977[i + 0]) );
  }
  i1972.m_ControlSchemes = i1976
  return i1972
}

Deserializers["UnityEngine.InputSystem.InputActionMap"] = function (request, data, root) {
  var i1980 = root || request.c( 'UnityEngine.InputSystem.InputActionMap' )
  var i1981 = data
  i1980.m_Name = i1981[0]
  i1980.m_Id = i1981[1]
  request.r(i1981[2], i1981[3], 0, i1980, 'm_Asset')
  var i1983 = i1981[4]
  var i1982 = []
  for(var i = 0; i < i1983.length; i += 1) {
    i1982.push( request.d('UnityEngine.InputSystem.InputAction', i1983[i + 0]) );
  }
  i1980.m_Actions = i1982
  var i1985 = i1981[5]
  var i1984 = []
  for(var i = 0; i < i1985.length; i += 1) {
    i1984.push( request.d('UnityEngine.InputSystem.InputBinding', i1985[i + 0]) );
  }
  i1980.m_Bindings = i1984
  return i1980
}

Deserializers["UnityEngine.InputSystem.InputAction"] = function (request, data, root) {
  var i1988 = root || request.c( 'UnityEngine.InputSystem.InputAction' )
  var i1989 = data
  i1988.m_Name = i1989[0]
  i1988.m_Type = i1989[1]
  i1988.m_ExpectedControlType = i1989[2]
  i1988.m_Id = i1989[3]
  i1988.m_Processors = i1989[4]
  i1988.m_Interactions = i1989[5]
  var i1991 = i1989[6]
  var i1990 = []
  for(var i = 0; i < i1991.length; i += 1) {
    i1990.push( request.d('UnityEngine.InputSystem.InputBinding', i1991[i + 0]) );
  }
  i1988.m_SingletonActionBindings = i1990
  i1988.m_Flags = i1989[7]
  return i1988
}

Deserializers["UnityEngine.InputSystem.InputBinding"] = function (request, data, root) {
  var i1994 = root || request.c( 'UnityEngine.InputSystem.InputBinding' )
  var i1995 = data
  i1994.m_Name = i1995[0]
  i1994.m_Id = i1995[1]
  i1994.m_Path = i1995[2]
  i1994.m_Interactions = i1995[3]
  i1994.m_Processors = i1995[4]
  i1994.m_Groups = i1995[5]
  i1994.m_Action = i1995[6]
  i1994.m_Flags = i1995[7]
  return i1994
}

Deserializers["UnityEngine.InputSystem.InputControlScheme"] = function (request, data, root) {
  var i1998 = root || request.c( 'UnityEngine.InputSystem.InputControlScheme' )
  var i1999 = data
  i1998.m_Name = i1999[0]
  i1998.m_BindingGroup = i1999[1]
  var i2001 = i1999[2]
  var i2000 = []
  for(var i = 0; i < i2001.length; i += 1) {
    i2000.push( request.d('UnityEngine.InputSystem.InputControlScheme+DeviceRequirement', i2001[i + 0]) );
  }
  i1998.m_DeviceRequirements = i2000
  return i1998
}

Deserializers["UnityEngine.InputSystem.InputControlScheme+DeviceRequirement"] = function (request, data, root) {
  var i2004 = root || request.c( 'UnityEngine.InputSystem.InputControlScheme+DeviceRequirement' )
  var i2005 = data
  i2004.m_ControlPath = i2005[0]
  i2004.m_Flags = i2005[1]
  return i2004
}

Deserializers["UnityEngine.InputSystem.InputActionReference"] = function (request, data, root) {
  var i2006 = root || request.c( 'UnityEngine.InputSystem.InputActionReference' )
  var i2007 = data
  request.r(i2007[0], i2007[1], 0, i2006, 'm_Asset')
  i2006.m_ActionId = i2007[2]
  return i2006
}

Deserializers["IconDataConfig"] = function (request, data, root) {
  var i2008 = root || request.c( 'IconDataConfig' )
  var i2009 = data
  var i2011 = i2009[0]
  var i2010 = new (System.Collections.Generic.List$1(Bridge.ns('IconConfig')))
  for(var i = 0; i < i2011.length; i += 1) {
    i2010.add(request.d('IconConfig', i2011[i + 0]));
  }
  i2008.listIcon = i2010
  var i2013 = i2009[1]
  var i2012 = new (System.Collections.Generic.List$1(Bridge.ns('IconData')))
  for(var i = 0; i < i2013.length; i += 1) {
    i2012.add(request.d('IconData', i2013[i + 0]));
  }
  i2008.listIconData = i2012
  i2008.levelFolderPath = i2009[2]
  return i2008
}

Deserializers["IconConfig"] = function (request, data, root) {
  var i2016 = root || request.c( 'IconConfig' )
  var i2017 = data
  i2016.type = i2017[0]
  request.r(i2017[1], i2017[2], 0, i2016, 'sprite')
  return i2016
}

Deserializers["IconData"] = function (request, data, root) {
  var i2020 = root || request.c( 'IconData' )
  var i2021 = data
  i2020.notificationType = i2021[0]
  i2020.iconType = i2021[1]
  return i2020
}

Deserializers["TMPro.TMP_FontAsset"] = function (request, data, root) {
  var i2022 = root || request.c( 'TMPro.TMP_FontAsset' )
  var i2023 = data
  i2022.hashCode = i2023[0]
  request.r(i2023[1], i2023[2], 0, i2022, 'material')
  i2022.materialHashCode = i2023[3]
  request.r(i2023[4], i2023[5], 0, i2022, 'atlas')
  i2022.normalStyle = i2023[6]
  i2022.normalSpacingOffset = i2023[7]
  i2022.boldStyle = i2023[8]
  i2022.boldSpacing = i2023[9]
  i2022.italicStyle = i2023[10]
  i2022.tabSize = i2023[11]
  i2022.m_Version = i2023[12]
  i2022.m_SourceFontFileGUID = i2023[13]
  request.r(i2023[14], i2023[15], 0, i2022, 'm_SourceFontFile_EditorRef')
  request.r(i2023[16], i2023[17], 0, i2022, 'm_SourceFontFile')
  i2022.m_AtlasPopulationMode = i2023[18]
  i2022.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i2023[19], i2022.m_FaceInfo)
  var i2025 = i2023[20]
  var i2024 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.Glyph')))
  for(var i = 0; i < i2025.length; i += 1) {
    i2024.add(request.d('UnityEngine.TextCore.Glyph', i2025[i + 0]));
  }
  i2022.m_GlyphTable = i2024
  var i2027 = i2023[21]
  var i2026 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Character')))
  for(var i = 0; i < i2027.length; i += 1) {
    i2026.add(request.d('TMPro.TMP_Character', i2027[i + 0]));
  }
  i2022.m_CharacterTable = i2026
  var i2029 = i2023[22]
  var i2028 = []
  for(var i = 0; i < i2029.length; i += 2) {
  request.r(i2029[i + 0], i2029[i + 1], 2, i2028, '')
  }
  i2022.m_AtlasTextures = i2028
  i2022.m_AtlasTextureIndex = i2023[23]
  i2022.m_IsMultiAtlasTexturesEnabled = !!i2023[24]
  i2022.m_ClearDynamicDataOnBuild = !!i2023[25]
  var i2031 = i2023[26]
  var i2030 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i2031.length; i += 1) {
    i2030.add(request.d('UnityEngine.TextCore.GlyphRect', i2031[i + 0]));
  }
  i2022.m_UsedGlyphRects = i2030
  var i2033 = i2023[27]
  var i2032 = new (System.Collections.Generic.List$1(Bridge.ns('UnityEngine.TextCore.GlyphRect')))
  for(var i = 0; i < i2033.length; i += 1) {
    i2032.add(request.d('UnityEngine.TextCore.GlyphRect', i2033[i + 0]));
  }
  i2022.m_FreeGlyphRects = i2032
  i2022.m_fontInfo = request.d('TMPro.FaceInfo_Legacy', i2023[28], i2022.m_fontInfo)
  i2022.m_AtlasWidth = i2023[29]
  i2022.m_AtlasHeight = i2023[30]
  i2022.m_AtlasPadding = i2023[31]
  i2022.m_AtlasRenderMode = i2023[32]
  var i2035 = i2023[33]
  var i2034 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Glyph')))
  for(var i = 0; i < i2035.length; i += 1) {
    i2034.add(request.d('TMPro.TMP_Glyph', i2035[i + 0]));
  }
  i2022.m_glyphInfoList = i2034
  i2022.m_KerningTable = request.d('TMPro.KerningTable', i2023[34], i2022.m_KerningTable)
  i2022.m_FontFeatureTable = request.d('TMPro.TMP_FontFeatureTable', i2023[35], i2022.m_FontFeatureTable)
  var i2037 = i2023[36]
  var i2036 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i2037.length; i += 2) {
  request.r(i2037[i + 0], i2037[i + 1], 1, i2036, '')
  }
  i2022.fallbackFontAssets = i2036
  var i2039 = i2023[37]
  var i2038 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i2039.length; i += 2) {
  request.r(i2039[i + 0], i2039[i + 1], 1, i2038, '')
  }
  i2022.m_FallbackFontAssetTable = i2038
  i2022.m_CreationSettings = request.d('TMPro.FontAssetCreationSettings', i2023[38], i2022.m_CreationSettings)
  var i2041 = i2023[39]
  var i2040 = []
  for(var i = 0; i < i2041.length; i += 1) {
    i2040.push( request.d('TMPro.TMP_FontWeightPair', i2041[i + 0]) );
  }
  i2022.m_FontWeightTable = i2040
  var i2043 = i2023[40]
  var i2042 = []
  for(var i = 0; i < i2043.length; i += 1) {
    i2042.push( request.d('TMPro.TMP_FontWeightPair', i2043[i + 0]) );
  }
  i2022.fontWeights = i2042
  return i2022
}

Deserializers["UnityEngine.TextCore.FaceInfo"] = function (request, data, root) {
  var i2044 = root || request.c( 'UnityEngine.TextCore.FaceInfo' )
  var i2045 = data
  i2044.m_FaceIndex = i2045[0]
  i2044.m_FamilyName = i2045[1]
  i2044.m_StyleName = i2045[2]
  i2044.m_PointSize = i2045[3]
  i2044.m_Scale = i2045[4]
  i2044.m_UnitsPerEM = i2045[5]
  i2044.m_LineHeight = i2045[6]
  i2044.m_AscentLine = i2045[7]
  i2044.m_CapLine = i2045[8]
  i2044.m_MeanLine = i2045[9]
  i2044.m_Baseline = i2045[10]
  i2044.m_DescentLine = i2045[11]
  i2044.m_SuperscriptOffset = i2045[12]
  i2044.m_SuperscriptSize = i2045[13]
  i2044.m_SubscriptOffset = i2045[14]
  i2044.m_SubscriptSize = i2045[15]
  i2044.m_UnderlineOffset = i2045[16]
  i2044.m_UnderlineThickness = i2045[17]
  i2044.m_StrikethroughOffset = i2045[18]
  i2044.m_StrikethroughThickness = i2045[19]
  i2044.m_TabWidth = i2045[20]
  return i2044
}

Deserializers["UnityEngine.TextCore.Glyph"] = function (request, data, root) {
  var i2048 = root || request.c( 'UnityEngine.TextCore.Glyph' )
  var i2049 = data
  i2048.m_Index = i2049[0]
  i2048.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i2049[1], i2048.m_Metrics)
  i2048.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i2049[2], i2048.m_GlyphRect)
  i2048.m_Scale = i2049[3]
  i2048.m_AtlasIndex = i2049[4]
  i2048.m_ClassDefinitionType = i2049[5]
  return i2048
}

Deserializers["UnityEngine.TextCore.GlyphMetrics"] = function (request, data, root) {
  var i2050 = root || request.c( 'UnityEngine.TextCore.GlyphMetrics' )
  var i2051 = data
  i2050.m_Width = i2051[0]
  i2050.m_Height = i2051[1]
  i2050.m_HorizontalBearingX = i2051[2]
  i2050.m_HorizontalBearingY = i2051[3]
  i2050.m_HorizontalAdvance = i2051[4]
  return i2050
}

Deserializers["UnityEngine.TextCore.GlyphRect"] = function (request, data, root) {
  var i2052 = root || request.c( 'UnityEngine.TextCore.GlyphRect' )
  var i2053 = data
  i2052.m_X = i2053[0]
  i2052.m_Y = i2053[1]
  i2052.m_Width = i2053[2]
  i2052.m_Height = i2053[3]
  return i2052
}

Deserializers["TMPro.TMP_Character"] = function (request, data, root) {
  var i2056 = root || request.c( 'TMPro.TMP_Character' )
  var i2057 = data
  i2056.m_ElementType = i2057[0]
  i2056.m_Unicode = i2057[1]
  i2056.m_GlyphIndex = i2057[2]
  i2056.m_Scale = i2057[3]
  return i2056
}

Deserializers["TMPro.FaceInfo_Legacy"] = function (request, data, root) {
  var i2062 = root || request.c( 'TMPro.FaceInfo_Legacy' )
  var i2063 = data
  i2062.Name = i2063[0]
  i2062.PointSize = i2063[1]
  i2062.Scale = i2063[2]
  i2062.CharacterCount = i2063[3]
  i2062.LineHeight = i2063[4]
  i2062.Baseline = i2063[5]
  i2062.Ascender = i2063[6]
  i2062.CapHeight = i2063[7]
  i2062.Descender = i2063[8]
  i2062.CenterLine = i2063[9]
  i2062.SuperscriptOffset = i2063[10]
  i2062.SubscriptOffset = i2063[11]
  i2062.SubSize = i2063[12]
  i2062.Underline = i2063[13]
  i2062.UnderlineThickness = i2063[14]
  i2062.strikethrough = i2063[15]
  i2062.strikethroughThickness = i2063[16]
  i2062.TabWidth = i2063[17]
  i2062.Padding = i2063[18]
  i2062.AtlasWidth = i2063[19]
  i2062.AtlasHeight = i2063[20]
  return i2062
}

Deserializers["TMPro.TMP_Glyph"] = function (request, data, root) {
  var i2066 = root || request.c( 'TMPro.TMP_Glyph' )
  var i2067 = data
  i2066.id = i2067[0]
  i2066.x = i2067[1]
  i2066.y = i2067[2]
  i2066.width = i2067[3]
  i2066.height = i2067[4]
  i2066.xOffset = i2067[5]
  i2066.yOffset = i2067[6]
  i2066.xAdvance = i2067[7]
  i2066.scale = i2067[8]
  return i2066
}

Deserializers["TMPro.KerningTable"] = function (request, data, root) {
  var i2068 = root || request.c( 'TMPro.KerningTable' )
  var i2069 = data
  var i2071 = i2069[0]
  var i2070 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.KerningPair')))
  for(var i = 0; i < i2071.length; i += 1) {
    i2070.add(request.d('TMPro.KerningPair', i2071[i + 0]));
  }
  i2068.kerningPairs = i2070
  return i2068
}

Deserializers["TMPro.KerningPair"] = function (request, data, root) {
  var i2074 = root || request.c( 'TMPro.KerningPair' )
  var i2075 = data
  i2074.xOffset = i2075[0]
  i2074.m_FirstGlyph = i2075[1]
  i2074.m_FirstGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i2075[2], i2074.m_FirstGlyphAdjustments)
  i2074.m_SecondGlyph = i2075[3]
  i2074.m_SecondGlyphAdjustments = request.d('TMPro.GlyphValueRecord_Legacy', i2075[4], i2074.m_SecondGlyphAdjustments)
  i2074.m_IgnoreSpacingAdjustments = !!i2075[5]
  return i2074
}

Deserializers["TMPro.TMP_FontFeatureTable"] = function (request, data, root) {
  var i2076 = root || request.c( 'TMPro.TMP_FontFeatureTable' )
  var i2077 = data
  var i2079 = i2077[0]
  var i2078 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_GlyphPairAdjustmentRecord')))
  for(var i = 0; i < i2079.length; i += 1) {
    i2078.add(request.d('TMPro.TMP_GlyphPairAdjustmentRecord', i2079[i + 0]));
  }
  i2076.m_GlyphPairAdjustmentRecords = i2078
  return i2076
}

Deserializers["TMPro.TMP_GlyphPairAdjustmentRecord"] = function (request, data, root) {
  var i2082 = root || request.c( 'TMPro.TMP_GlyphPairAdjustmentRecord' )
  var i2083 = data
  i2082.m_FirstAdjustmentRecord = request.d('TMPro.TMP_GlyphAdjustmentRecord', i2083[0], i2082.m_FirstAdjustmentRecord)
  i2082.m_SecondAdjustmentRecord = request.d('TMPro.TMP_GlyphAdjustmentRecord', i2083[1], i2082.m_SecondAdjustmentRecord)
  i2082.m_FeatureLookupFlags = i2083[2]
  return i2082
}

Deserializers["TMPro.FontAssetCreationSettings"] = function (request, data, root) {
  var i2086 = root || request.c( 'TMPro.FontAssetCreationSettings' )
  var i2087 = data
  i2086.sourceFontFileName = i2087[0]
  i2086.sourceFontFileGUID = i2087[1]
  i2086.pointSizeSamplingMode = i2087[2]
  i2086.pointSize = i2087[3]
  i2086.padding = i2087[4]
  i2086.packingMode = i2087[5]
  i2086.atlasWidth = i2087[6]
  i2086.atlasHeight = i2087[7]
  i2086.characterSetSelectionMode = i2087[8]
  i2086.characterSequence = i2087[9]
  i2086.referencedFontAssetGUID = i2087[10]
  i2086.referencedTextAssetGUID = i2087[11]
  i2086.fontStyle = i2087[12]
  i2086.fontStyleModifier = i2087[13]
  i2086.renderMode = i2087[14]
  i2086.includeFontFeatures = !!i2087[15]
  return i2086
}

Deserializers["TMPro.TMP_FontWeightPair"] = function (request, data, root) {
  var i2090 = root || request.c( 'TMPro.TMP_FontWeightPair' )
  var i2091 = data
  request.r(i2091[0], i2091[1], 0, i2090, 'regularTypeface')
  request.r(i2091[2], i2091[3], 0, i2090, 'italicTypeface')
  return i2090
}

Deserializers["ChallengeConfig"] = function (request, data, root) {
  var i2092 = root || request.c( 'ChallengeConfig' )
  var i2093 = data
  i2092.LevelChallengeConfig = request.d('LevelChallengeConfig', i2093[0], i2092.LevelChallengeConfig)
  i2092.MultipleChallengeConfig = request.d('MultipleChallengeConfig', i2093[1], i2092.MultipleChallengeConfig)
  return i2092
}

Deserializers["MultipleChallengeConfig"] = function (request, data, root) {
  var i2094 = root || request.c( 'MultipleChallengeConfig' )
  var i2095 = data
  i2094.GiftNumber = i2095[0]
  i2094.GiftClaimReward = i2095[1]
  i2094.CoinReward = i2095[2]
  i2094.BonusMoneyPerBall = i2095[3]
  i2094.FirstLevelUnlock = i2095[4]
  var i2097 = i2095[5]
  var i2096 = new (System.Collections.Generic.List$1(Bridge.ns('MultipleChallengeConfigModel')))
  for(var i = 0; i < i2097.length; i += 1) {
    i2096.add(request.d('MultipleChallengeConfigModel', i2097[i + 0]));
  }
  i2094.Datas = i2096
  return i2094
}

Deserializers["TMPro.TMP_GlyphAdjustmentRecord"] = function (request, data, root) {
  var i2100 = root || request.c( 'TMPro.TMP_GlyphAdjustmentRecord' )
  var i2101 = data
  i2100.m_GlyphIndex = i2101[0]
  i2100.m_GlyphValueRecord = request.d('TMPro.TMP_GlyphValueRecord', i2101[1], i2100.m_GlyphValueRecord)
  return i2100
}

Deserializers["TMPro.TMP_GlyphValueRecord"] = function (request, data, root) {
  var i2102 = root || request.c( 'TMPro.TMP_GlyphValueRecord' )
  var i2103 = data
  i2102.m_XPlacement = i2103[0]
  i2102.m_YPlacement = i2103[1]
  i2102.m_XAdvance = i2103[2]
  i2102.m_YAdvance = i2103[3]
  return i2102
}

Deserializers["Spine.Unity.SkeletonDataAsset"] = function (request, data, root) {
  var i2104 = root || request.c( 'Spine.Unity.SkeletonDataAsset' )
  var i2105 = data
  var i2107 = i2105[0]
  var i2106 = []
  for(var i = 0; i < i2107.length; i += 2) {
  request.r(i2107[i + 0], i2107[i + 1], 2, i2106, '')
  }
  i2104.atlasAssets = i2106
  i2104.scale = i2105[1]
  request.r(i2105[2], i2105[3], 0, i2104, 'skeletonJSON')
  i2104.isUpgradingBlendModeMaterials = !!i2105[4]
  i2104.blendModeMaterials = request.d('Spine.Unity.BlendModeMaterials', i2105[5], i2104.blendModeMaterials)
  var i2109 = i2105[6]
  var i2108 = new (System.Collections.Generic.List$1(Bridge.ns('Spine.Unity.SkeletonDataModifierAsset')))
  for(var i = 0; i < i2109.length; i += 2) {
  request.r(i2109[i + 0], i2109[i + 1], 1, i2108, '')
  }
  i2104.skeletonDataModifiers = i2108
  var i2111 = i2105[7]
  var i2110 = []
  for(var i = 0; i < i2111.length; i += 1) {
    i2110.push( i2111[i + 0] );
  }
  i2104.fromAnimation = i2110
  var i2113 = i2105[8]
  var i2112 = []
  for(var i = 0; i < i2113.length; i += 1) {
    i2112.push( i2113[i + 0] );
  }
  i2104.toAnimation = i2112
  i2104.duration = i2105[9]
  i2104.defaultMix = i2105[10]
  request.r(i2105[11], i2105[12], 0, i2104, 'controller')
  return i2104
}

Deserializers["Spine.Unity.BlendModeMaterials"] = function (request, data, root) {
  var i2116 = root || request.c( 'Spine.Unity.BlendModeMaterials' )
  var i2117 = data
  i2116.applyAdditiveMaterial = !!i2117[0]
  var i2119 = i2117[1]
  var i2118 = new (System.Collections.Generic.List$1(Bridge.ns('Spine.Unity.BlendModeMaterials+ReplacementMaterial')))
  for(var i = 0; i < i2119.length; i += 1) {
    i2118.add(request.d('Spine.Unity.BlendModeMaterials+ReplacementMaterial', i2119[i + 0]));
  }
  i2116.additiveMaterials = i2118
  var i2121 = i2117[2]
  var i2120 = new (System.Collections.Generic.List$1(Bridge.ns('Spine.Unity.BlendModeMaterials+ReplacementMaterial')))
  for(var i = 0; i < i2121.length; i += 1) {
    i2120.add(request.d('Spine.Unity.BlendModeMaterials+ReplacementMaterial', i2121[i + 0]));
  }
  i2116.multiplyMaterials = i2120
  var i2123 = i2117[3]
  var i2122 = new (System.Collections.Generic.List$1(Bridge.ns('Spine.Unity.BlendModeMaterials+ReplacementMaterial')))
  for(var i = 0; i < i2123.length; i += 1) {
    i2122.add(request.d('Spine.Unity.BlendModeMaterials+ReplacementMaterial', i2123[i + 0]));
  }
  i2116.screenMaterials = i2122
  i2116.requiresBlendModeMaterials = !!i2117[4]
  return i2116
}

Deserializers["Spine.Unity.BlendModeMaterials+ReplacementMaterial"] = function (request, data, root) {
  var i2126 = root || request.c( 'Spine.Unity.BlendModeMaterials+ReplacementMaterial' )
  var i2127 = data
  i2126.pageName = i2127[0]
  request.r(i2127[1], i2127[2], 0, i2126, 'material')
  return i2126
}

Deserializers["Spine.Unity.SpineAtlasAsset"] = function (request, data, root) {
  var i2130 = root || request.c( 'Spine.Unity.SpineAtlasAsset' )
  var i2131 = data
  request.r(i2131[0], i2131[1], 0, i2130, 'atlasFile')
  var i2133 = i2131[2]
  var i2132 = []
  for(var i = 0; i < i2133.length; i += 2) {
  request.r(i2133[i + 0], i2133[i + 1], 2, i2132, '')
  }
  i2130.materials = i2132
  return i2130
}

Deserializers["GameConfig"] = function (request, data, root) {
  var i2134 = root || request.c( 'GameConfig' )
  var i2135 = data
  i2134.durationPopup = i2135[0]
  i2134.maxLevel = i2135[1]
  i2134.startLoopLevel = i2135[2]
  i2134.coinWin = i2135[3]
  i2134.currencyWatchAds = i2135[4]
  i2134.percentWinGiftPerLevel = i2135[5]
  i2134.receiveCoinWinFullItem = i2135[6]
  return i2134
}

Deserializers["SoundConfig"] = function (request, data, root) {
  var i2136 = root || request.c( 'SoundConfig' )
  var i2137 = data
  var i2139 = i2137[0]
  var i2138 = new (System.Collections.Generic.List$1(Bridge.ns('SoundData')))
  for(var i = 0; i < i2139.length; i += 1) {
    i2138.add(request.d('SoundData', i2139[i + 0]));
  }
  i2136.SoundDatas = i2138
  return i2136
}

Deserializers["SoundData"] = function (request, data, root) {
  var i2142 = root || request.c( 'SoundData' )
  var i2143 = data
  i2142.SoundType = i2143[0]
  request.r(i2143[1], i2143[2], 0, i2142, 'Clip')
  return i2142
}

Deserializers["ItemConfig"] = function (request, data, root) {
  var i2144 = root || request.c( 'ItemConfig' )
  var i2145 = data
  var i2147 = i2145[0]
  var i2146 = new (System.Collections.Generic.List$1(Bridge.ns('BallData')))
  for(var i = 0; i < i2147.length; i += 1) {
    i2146.add(request.d('BallData', i2147[i + 0]));
  }
  i2144.ballDataList = i2146
  var i2149 = i2145[1]
  var i2148 = new (System.Collections.Generic.List$1(Bridge.ns('PinData')))
  for(var i = 0; i < i2149.length; i += 1) {
    i2148.add(request.d('PinData', i2149[i + 0]));
  }
  i2144.pinDataList = i2148
  var i2151 = i2145[2]
  var i2150 = new (System.Collections.Generic.List$1(Bridge.ns('ThemeData')))
  for(var i = 0; i < i2151.length; i += 1) {
    i2150.add(request.d('ThemeData', i2151[i + 0]));
  }
  i2144.themeDataList = i2150
  var i2153 = i2145[3]
  var i2152 = new (System.Collections.Generic.List$1(Bridge.ns('TrailData')))
  for(var i = 0; i < i2153.length; i += 1) {
    i2152.add(request.d('TrailData', i2153[i + 0]));
  }
  i2144.trailDataList = i2152
  var i2155 = i2145[4]
  var i2154 = new (System.Collections.Generic.List$1(Bridge.ns('ItemData')))
  for(var i = 0; i < i2155.length; i += 1) {
    i2154.add(request.d('ItemData', i2155[i + 0]));
  }
  i2144.avatarDataList = i2154
  return i2144
}

Deserializers["BallData"] = function (request, data, root) {
  var i2158 = root || request.c( 'BallData' )
  var i2159 = data
  i2158.TypeItem = i2159[0]
  i2158.Id = i2159[1]
  request.r(i2159[2], i2159[3], 0, i2158, 'ImageBg')
  request.r(i2159[4], i2159[5], 0, i2158, 'ImageIcon')
  i2158.PurchaseType = i2159[6]
  i2158.coin = i2159[7]
  i2158.LevelUnlock = i2159[8]
  i2158.EventType = i2159[9]
  i2158.CollectNumber = i2159[10]
  request.r(i2159[11], i2159[12], 0, i2158, 'itemModel')
  request.r(i2159[13], i2159[14], 0, i2158, 'ballSkin')
  return i2158
}

Deserializers["PinData"] = function (request, data, root) {
  var i2162 = root || request.c( 'PinData' )
  var i2163 = data
  i2162.TypeItem = i2163[0]
  i2162.Id = i2163[1]
  request.r(i2163[2], i2163[3], 0, i2162, 'ImageBg')
  request.r(i2163[4], i2163[5], 0, i2162, 'ImageIcon')
  i2162.PurchaseType = i2163[6]
  i2162.coin = i2163[7]
  i2162.LevelUnlock = i2163[8]
  i2162.EventType = i2163[9]
  i2162.CollectNumber = i2163[10]
  request.r(i2163[11], i2163[12], 0, i2162, 'itemModel')
  request.r(i2163[13], i2163[14], 0, i2162, 'pinSkin')
  return i2162
}

Deserializers["ThemeData"] = function (request, data, root) {
  var i2166 = root || request.c( 'ThemeData' )
  var i2167 = data
  i2166.TypeItem = i2167[0]
  i2166.Id = i2167[1]
  request.r(i2167[2], i2167[3], 0, i2166, 'ImageBg')
  request.r(i2167[4], i2167[5], 0, i2166, 'ImageIcon')
  i2166.PurchaseType = i2167[6]
  i2166.coin = i2167[7]
  i2166.LevelUnlock = i2167[8]
  i2166.EventType = i2167[9]
  i2166.CollectNumber = i2167[10]
  request.r(i2167[11], i2167[12], 0, i2166, 'itemModel')
  request.r(i2167[13], i2167[14], 0, i2166, 'backgroundSkin')
  request.r(i2167[15], i2167[16], 0, i2166, 'wallMaterial')
  return i2166
}

Deserializers["TrailData"] = function (request, data, root) {
  var i2170 = root || request.c( 'TrailData' )
  var i2171 = data
  i2170.TypeItem = i2171[0]
  i2170.Id = i2171[1]
  request.r(i2171[2], i2171[3], 0, i2170, 'ImageBg')
  request.r(i2171[4], i2171[5], 0, i2170, 'ImageIcon')
  i2170.PurchaseType = i2171[6]
  i2170.coin = i2171[7]
  i2170.LevelUnlock = i2171[8]
  i2170.EventType = i2171[9]
  i2170.CollectNumber = i2171[10]
  request.r(i2171[11], i2171[12], 0, i2170, 'itemModel')
  request.r(i2171[13], i2171[14], 0, i2170, 'trailPrefab')
  i2170.trailSize = i2171[15]
  return i2170
}

Deserializers["ItemData"] = function (request, data, root) {
  var i2174 = root || request.c( 'ItemData' )
  var i2175 = data
  i2174.TypeItem = i2175[0]
  i2174.Id = i2175[1]
  request.r(i2175[2], i2175[3], 0, i2174, 'ImageBg')
  request.r(i2175[4], i2175[5], 0, i2174, 'ImageIcon')
  i2174.PurchaseType = i2175[6]
  i2174.coin = i2175[7]
  i2174.LevelUnlock = i2175[8]
  i2174.EventType = i2175[9]
  i2174.CollectNumber = i2175[10]
  request.r(i2175[11], i2175[12], 0, i2174, 'itemModel')
  return i2174
}

Deserializers["GameEventConfig"] = function (request, data, root) {
  var i2176 = root || request.c( 'GameEventConfig' )
  var i2177 = data
  var i2179 = i2177[0]
  var i2178 = new (System.Collections.Generic.List$1(Bridge.ns('GameEventData')))
  for(var i = 0; i < i2179.length; i += 1) {
    i2178.add(request.d('GameEventData', i2179[i + 0]));
  }
  i2176.gameEvents = i2178
  return i2176
}

Deserializers["GameEventData"] = function (request, data, root) {
  var i2182 = root || request.c( 'GameEventData' )
  var i2183 = data
  i2182.gameEventType = i2183[0]
  i2182.timeEnd = request.d('GameEventTime', i2183[1], i2182.timeEnd)
  return i2182
}

Deserializers["GameEventTime"] = function (request, data, root) {
  var i2184 = root || request.c( 'GameEventTime' )
  var i2185 = data
  i2184.day = i2185[0]
  i2184.month = i2185[1]
  i2184.year = i2185[2]
  return i2184
}

Deserializers["DG.Tweening.Core.DOTweenSettings"] = function (request, data, root) {
  var i2186 = root || request.c( 'DG.Tweening.Core.DOTweenSettings' )
  var i2187 = data
  i2186.useSafeMode = !!i2187[0]
  i2186.safeModeOptions = request.d('DG.Tweening.Core.DOTweenSettings+SafeModeOptions', i2187[1], i2186.safeModeOptions)
  i2186.timeScale = i2187[2]
  i2186.useSmoothDeltaTime = !!i2187[3]
  i2186.maxSmoothUnscaledTime = i2187[4]
  i2186.rewindCallbackMode = i2187[5]
  i2186.showUnityEditorReport = !!i2187[6]
  i2186.logBehaviour = i2187[7]
  i2186.drawGizmos = !!i2187[8]
  i2186.defaultRecyclable = !!i2187[9]
  i2186.defaultAutoPlay = i2187[10]
  i2186.defaultUpdateType = i2187[11]
  i2186.defaultTimeScaleIndependent = !!i2187[12]
  i2186.defaultEaseType = i2187[13]
  i2186.defaultEaseOvershootOrAmplitude = i2187[14]
  i2186.defaultEasePeriod = i2187[15]
  i2186.defaultAutoKill = !!i2187[16]
  i2186.defaultLoopType = i2187[17]
  i2186.debugMode = !!i2187[18]
  i2186.debugStoreTargetId = !!i2187[19]
  i2186.showPreviewPanel = !!i2187[20]
  i2186.storeSettingsLocation = i2187[21]
  i2186.modules = request.d('DG.Tweening.Core.DOTweenSettings+ModulesSetup', i2187[22], i2186.modules)
  i2186.createASMDEF = !!i2187[23]
  i2186.showPlayingTweens = !!i2187[24]
  i2186.showPausedTweens = !!i2187[25]
  return i2186
}

Deserializers["DG.Tweening.Core.DOTweenSettings+SafeModeOptions"] = function (request, data, root) {
  var i2188 = root || request.c( 'DG.Tweening.Core.DOTweenSettings+SafeModeOptions' )
  var i2189 = data
  i2188.logBehaviour = i2189[0]
  i2188.nestedTweenFailureBehaviour = i2189[1]
  return i2188
}

Deserializers["DG.Tweening.Core.DOTweenSettings+ModulesSetup"] = function (request, data, root) {
  var i2190 = root || request.c( 'DG.Tweening.Core.DOTweenSettings+ModulesSetup' )
  var i2191 = data
  i2190.showPanel = !!i2191[0]
  i2190.audioEnabled = !!i2191[1]
  i2190.physicsEnabled = !!i2191[2]
  i2190.physics2DEnabled = !!i2191[3]
  i2190.spriteEnabled = !!i2191[4]
  i2190.uiEnabled = !!i2191[5]
  i2190.textMeshProEnabled = !!i2191[6]
  i2190.tk2DEnabled = !!i2191[7]
  i2190.deAudioEnabled = !!i2191[8]
  i2190.deUnityExtendedEnabled = !!i2191[9]
  i2190.epoOutlineEnabled = !!i2191[10]
  return i2190
}

Deserializers["TMPro.TMP_Settings"] = function (request, data, root) {
  var i2192 = root || request.c( 'TMPro.TMP_Settings' )
  var i2193 = data
  i2192.m_enableWordWrapping = !!i2193[0]
  i2192.m_enableKerning = !!i2193[1]
  i2192.m_enableExtraPadding = !!i2193[2]
  i2192.m_enableTintAllSprites = !!i2193[3]
  i2192.m_enableParseEscapeCharacters = !!i2193[4]
  i2192.m_EnableRaycastTarget = !!i2193[5]
  i2192.m_GetFontFeaturesAtRuntime = !!i2193[6]
  i2192.m_missingGlyphCharacter = i2193[7]
  i2192.m_warningsDisabled = !!i2193[8]
  request.r(i2193[9], i2193[10], 0, i2192, 'm_defaultFontAsset')
  i2192.m_defaultFontAssetPath = i2193[11]
  i2192.m_defaultFontSize = i2193[12]
  i2192.m_defaultAutoSizeMinRatio = i2193[13]
  i2192.m_defaultAutoSizeMaxRatio = i2193[14]
  i2192.m_defaultTextMeshProTextContainerSize = new pc.Vec2( i2193[15], i2193[16] )
  i2192.m_defaultTextMeshProUITextContainerSize = new pc.Vec2( i2193[17], i2193[18] )
  i2192.m_autoSizeTextContainer = !!i2193[19]
  i2192.m_IsTextObjectScaleStatic = !!i2193[20]
  var i2195 = i2193[21]
  var i2194 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_FontAsset')))
  for(var i = 0; i < i2195.length; i += 2) {
  request.r(i2195[i + 0], i2195[i + 1], 1, i2194, '')
  }
  i2192.m_fallbackFontAssets = i2194
  i2192.m_matchMaterialPreset = !!i2193[22]
  request.r(i2193[23], i2193[24], 0, i2192, 'm_defaultSpriteAsset')
  i2192.m_defaultSpriteAssetPath = i2193[25]
  i2192.m_enableEmojiSupport = !!i2193[26]
  i2192.m_MissingCharacterSpriteUnicode = i2193[27]
  i2192.m_defaultColorGradientPresetsPath = i2193[28]
  request.r(i2193[29], i2193[30], 0, i2192, 'm_defaultStyleSheet')
  i2192.m_StyleSheetsResourcePath = i2193[31]
  request.r(i2193[32], i2193[33], 0, i2192, 'm_leadingCharacters')
  request.r(i2193[34], i2193[35], 0, i2192, 'm_followingCharacters')
  i2192.m_UseModernHangulLineBreakingRules = !!i2193[36]
  return i2192
}

Deserializers["TMPro.TMP_SpriteAsset"] = function (request, data, root) {
  var i2196 = root || request.c( 'TMPro.TMP_SpriteAsset' )
  var i2197 = data
  i2196.hashCode = i2197[0]
  request.r(i2197[1], i2197[2], 0, i2196, 'material')
  i2196.materialHashCode = i2197[3]
  request.r(i2197[4], i2197[5], 0, i2196, 'spriteSheet')
  var i2199 = i2197[6]
  var i2198 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Sprite')))
  for(var i = 0; i < i2199.length; i += 1) {
    i2198.add(request.d('TMPro.TMP_Sprite', i2199[i + 0]));
  }
  i2196.spriteInfoList = i2198
  var i2201 = i2197[7]
  var i2200 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteAsset')))
  for(var i = 0; i < i2201.length; i += 2) {
  request.r(i2201[i + 0], i2201[i + 1], 1, i2200, '')
  }
  i2196.fallbackSpriteAssets = i2200
  i2196.m_Version = i2197[8]
  i2196.m_FaceInfo = request.d('UnityEngine.TextCore.FaceInfo', i2197[9], i2196.m_FaceInfo)
  var i2203 = i2197[10]
  var i2202 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteCharacter')))
  for(var i = 0; i < i2203.length; i += 1) {
    i2202.add(request.d('TMPro.TMP_SpriteCharacter', i2203[i + 0]));
  }
  i2196.m_SpriteCharacterTable = i2202
  var i2205 = i2197[11]
  var i2204 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_SpriteGlyph')))
  for(var i = 0; i < i2205.length; i += 1) {
    i2204.add(request.d('TMPro.TMP_SpriteGlyph', i2205[i + 0]));
  }
  i2196.m_SpriteGlyphTable = i2204
  return i2196
}

Deserializers["TMPro.TMP_Sprite"] = function (request, data, root) {
  var i2208 = root || request.c( 'TMPro.TMP_Sprite' )
  var i2209 = data
  i2208.name = i2209[0]
  i2208.hashCode = i2209[1]
  i2208.unicode = i2209[2]
  i2208.pivot = new pc.Vec2( i2209[3], i2209[4] )
  request.r(i2209[5], i2209[6], 0, i2208, 'sprite')
  i2208.id = i2209[7]
  i2208.x = i2209[8]
  i2208.y = i2209[9]
  i2208.width = i2209[10]
  i2208.height = i2209[11]
  i2208.xOffset = i2209[12]
  i2208.yOffset = i2209[13]
  i2208.xAdvance = i2209[14]
  i2208.scale = i2209[15]
  return i2208
}

Deserializers["TMPro.TMP_SpriteCharacter"] = function (request, data, root) {
  var i2214 = root || request.c( 'TMPro.TMP_SpriteCharacter' )
  var i2215 = data
  i2214.m_Name = i2215[0]
  i2214.m_HashCode = i2215[1]
  i2214.m_ElementType = i2215[2]
  i2214.m_Unicode = i2215[3]
  i2214.m_GlyphIndex = i2215[4]
  i2214.m_Scale = i2215[5]
  return i2214
}

Deserializers["TMPro.TMP_SpriteGlyph"] = function (request, data, root) {
  var i2218 = root || request.c( 'TMPro.TMP_SpriteGlyph' )
  var i2219 = data
  request.r(i2219[0], i2219[1], 0, i2218, 'sprite')
  i2218.m_Index = i2219[2]
  i2218.m_Metrics = request.d('UnityEngine.TextCore.GlyphMetrics', i2219[3], i2218.m_Metrics)
  i2218.m_GlyphRect = request.d('UnityEngine.TextCore.GlyphRect', i2219[4], i2218.m_GlyphRect)
  i2218.m_Scale = i2219[5]
  i2218.m_AtlasIndex = i2219[6]
  i2218.m_ClassDefinitionType = i2219[7]
  return i2218
}

Deserializers["TMPro.TMP_StyleSheet"] = function (request, data, root) {
  var i2220 = root || request.c( 'TMPro.TMP_StyleSheet' )
  var i2221 = data
  var i2223 = i2221[0]
  var i2222 = new (System.Collections.Generic.List$1(Bridge.ns('TMPro.TMP_Style')))
  for(var i = 0; i < i2223.length; i += 1) {
    i2222.add(request.d('TMPro.TMP_Style', i2223[i + 0]));
  }
  i2220.m_StyleList = i2222
  return i2220
}

Deserializers["TMPro.TMP_Style"] = function (request, data, root) {
  var i2226 = root || request.c( 'TMPro.TMP_Style' )
  var i2227 = data
  i2226.m_Name = i2227[0]
  i2226.m_HashCode = i2227[1]
  i2226.m_OpeningDefinition = i2227[2]
  i2226.m_ClosingDefinition = i2227[3]
  i2226.m_OpeningTagArray = i2227[4]
  i2226.m_ClosingTagArray = i2227[5]
  i2226.m_OpeningTagUnicodeArray = i2227[6]
  i2226.m_ClosingTagUnicodeArray = i2227[7]
  return i2226
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources"] = function (request, data, root) {
  var i2228 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources' )
  var i2229 = data
  var i2231 = i2229[0]
  var i2230 = []
  for(var i = 0; i < i2231.length; i += 1) {
    i2230.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.Resources+File', i2231[i + 0]) );
  }
  i2228.files = i2230
  i2228.componentToPrefabIds = i2229[1]
  return i2228
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.Resources+File"] = function (request, data, root) {
  var i2234 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.Resources+File' )
  var i2235 = data
  i2234.path = i2235[0]
  request.r(i2235[1], i2235[2], 0, i2234, 'unityObject')
  return i2234
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings"] = function (request, data, root) {
  var i2236 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings' )
  var i2237 = data
  var i2239 = i2237[0]
  var i2238 = []
  for(var i = 0; i < i2239.length; i += 1) {
    i2238.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder', i2239[i + 0]) );
  }
  i2236.scriptsExecutionOrder = i2238
  var i2241 = i2237[1]
  var i2240 = []
  for(var i = 0; i < i2241.length; i += 1) {
    i2240.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer', i2241[i + 0]) );
  }
  i2236.sortingLayers = i2240
  var i2243 = i2237[2]
  var i2242 = []
  for(var i = 0; i < i2243.length; i += 1) {
    i2242.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer', i2243[i + 0]) );
  }
  i2236.cullingLayers = i2242
  i2236.timeSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings', i2237[3], i2236.timeSettings)
  i2236.physicsSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings', i2237[4], i2236.physicsSettings)
  i2236.physics2DSettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings', i2237[5], i2236.physics2DSettings)
  i2236.qualitySettings = request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i2237[6], i2236.qualitySettings)
  i2236.enableRealtimeShadows = !!i2237[7]
  i2236.enableAutoInstancing = !!i2237[8]
  i2236.enableDynamicBatching = !!i2237[9]
  i2236.lightmapEncodingQuality = i2237[10]
  i2236.desiredColorSpace = i2237[11]
  var i2245 = i2237[12]
  var i2244 = []
  for(var i = 0; i < i2245.length; i += 1) {
    i2244.push( i2245[i + 0] );
  }
  i2236.allTags = i2244
  return i2236
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder"] = function (request, data, root) {
  var i2248 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder' )
  var i2249 = data
  i2248.name = i2249[0]
  i2248.value = i2249[1]
  return i2248
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer"] = function (request, data, root) {
  var i2252 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer' )
  var i2253 = data
  i2252.id = i2253[0]
  i2252.name = i2253[1]
  i2252.value = i2253[2]
  return i2252
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer"] = function (request, data, root) {
  var i2256 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer' )
  var i2257 = data
  i2256.id = i2257[0]
  i2256.name = i2257[1]
  return i2256
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings"] = function (request, data, root) {
  var i2258 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings' )
  var i2259 = data
  i2258.fixedDeltaTime = i2259[0]
  i2258.maximumDeltaTime = i2259[1]
  i2258.timeScale = i2259[2]
  i2258.maximumParticleTimestep = i2259[3]
  return i2258
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings"] = function (request, data, root) {
  var i2260 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings' )
  var i2261 = data
  i2260.gravity = new pc.Vec3( i2261[0], i2261[1], i2261[2] )
  i2260.defaultSolverIterations = i2261[3]
  i2260.bounceThreshold = i2261[4]
  i2260.autoSyncTransforms = !!i2261[5]
  i2260.autoSimulation = !!i2261[6]
  var i2263 = i2261[7]
  var i2262 = []
  for(var i = 0; i < i2263.length; i += 1) {
    i2262.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask', i2263[i + 0]) );
  }
  i2260.collisionMatrix = i2262
  return i2260
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask"] = function (request, data, root) {
  var i2266 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask' )
  var i2267 = data
  i2266.enabled = !!i2267[0]
  i2266.layerId = i2267[1]
  i2266.otherLayerId = i2267[2]
  return i2266
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings"] = function (request, data, root) {
  var i2268 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings' )
  var i2269 = data
  request.r(i2269[0], i2269[1], 0, i2268, 'material')
  i2268.gravity = new pc.Vec2( i2269[2], i2269[3] )
  i2268.positionIterations = i2269[4]
  i2268.velocityIterations = i2269[5]
  i2268.velocityThreshold = i2269[6]
  i2268.maxLinearCorrection = i2269[7]
  i2268.maxAngularCorrection = i2269[8]
  i2268.maxTranslationSpeed = i2269[9]
  i2268.maxRotationSpeed = i2269[10]
  i2268.baumgarteScale = i2269[11]
  i2268.baumgarteTOIScale = i2269[12]
  i2268.timeToSleep = i2269[13]
  i2268.linearSleepTolerance = i2269[14]
  i2268.angularSleepTolerance = i2269[15]
  i2268.defaultContactOffset = i2269[16]
  i2268.autoSimulation = !!i2269[17]
  i2268.queriesHitTriggers = !!i2269[18]
  i2268.queriesStartInColliders = !!i2269[19]
  i2268.callbacksOnDisable = !!i2269[20]
  i2268.reuseCollisionCallbacks = !!i2269[21]
  i2268.autoSyncTransforms = !!i2269[22]
  var i2271 = i2269[23]
  var i2270 = []
  for(var i = 0; i < i2271.length; i += 1) {
    i2270.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask', i2271[i + 0]) );
  }
  i2268.collisionMatrix = i2270
  return i2268
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask"] = function (request, data, root) {
  var i2274 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask' )
  var i2275 = data
  i2274.enabled = !!i2275[0]
  i2274.layerId = i2275[1]
  i2274.otherLayerId = i2275[2]
  return i2274
}

Deserializers["Luna.Unity.DTO.UnityEngine.Assets.QualitySettings"] = function (request, data, root) {
  var i2276 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Assets.QualitySettings' )
  var i2277 = data
  var i2279 = i2277[0]
  var i2278 = []
  for(var i = 0; i < i2279.length; i += 1) {
    i2278.push( request.d('Luna.Unity.DTO.UnityEngine.Assets.QualitySettings', i2279[i + 0]) );
  }
  i2276.qualityLevels = i2278
  var i2281 = i2277[1]
  var i2280 = []
  for(var i = 0; i < i2281.length; i += 1) {
    i2280.push( i2281[i + 0] );
  }
  i2276.names = i2280
  i2276.shadows = i2277[2]
  i2276.anisotropicFiltering = i2277[3]
  i2276.antiAliasing = i2277[4]
  i2276.lodBias = i2277[5]
  i2276.shadowCascades = i2277[6]
  i2276.shadowDistance = i2277[7]
  i2276.shadowmaskMode = i2277[8]
  i2276.shadowProjection = i2277[9]
  i2276.shadowResolution = i2277[10]
  i2276.softParticles = !!i2277[11]
  i2276.softVegetation = !!i2277[12]
  i2276.activeColorSpace = i2277[13]
  i2276.desiredColorSpace = i2277[14]
  i2276.masterTextureLimit = i2277[15]
  i2276.maxQueuedFrames = i2277[16]
  i2276.particleRaycastBudget = i2277[17]
  i2276.pixelLightCount = i2277[18]
  i2276.realtimeReflectionProbes = !!i2277[19]
  i2276.shadowCascade2Split = i2277[20]
  i2276.shadowCascade4Split = new pc.Vec3( i2277[21], i2277[22], i2277[23] )
  i2276.streamingMipmapsActive = !!i2277[24]
  i2276.vSyncCount = i2277[25]
  i2276.asyncUploadBufferSize = i2277[26]
  i2276.asyncUploadTimeSlice = i2277[27]
  i2276.billboardsFaceCameraPosition = !!i2277[28]
  i2276.shadowNearPlaneOffset = i2277[29]
  i2276.streamingMipmapsMemoryBudget = i2277[30]
  i2276.maximumLODLevel = i2277[31]
  i2276.streamingMipmapsAddAllCameras = !!i2277[32]
  i2276.streamingMipmapsMaxLevelReduction = i2277[33]
  i2276.streamingMipmapsRenderersPerFrame = i2277[34]
  i2276.resolutionScalingFixedDPIFactor = i2277[35]
  i2276.streamingMipmapsMaxFileIORequests = i2277[36]
  i2276.currentQualityLevel = i2277[37]
  return i2276
}

Deserializers["Dreamteck.Splines.SplineTrigger"] = function (request, data, root) {
  var i2286 = root || request.c( 'Dreamteck.Splines.SplineTrigger' )
  var i2287 = data
  i2286.name = i2287[0]
  i2286.type = i2287[1]
  i2286.workOnce = !!i2287[2]
  i2286.position = i2287[3]
  i2286.enabled = !!i2287[4]
  i2286.color = new pc.Color(i2287[5], i2287[6], i2287[7], i2287[8])
  i2286.onCross = request.d('Dreamteck.Splines.SplineTrigger+TriggerEvent', i2287[9], i2286.onCross)
  return i2286
}

Deserializers["Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition"] = function (request, data, root) {
  var i2290 = root || request.c( 'Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition' )
  var i2291 = data
  i2290.mode = i2291[0]
  i2290.parameter = i2291[1]
  i2290.threshold = i2291[2]
  return i2290
}

Deserializers["TMPro.GlyphValueRecord_Legacy"] = function (request, data, root) {
  var i2292 = root || request.c( 'TMPro.GlyphValueRecord_Legacy' )
  var i2293 = data
  i2292.xPlacement = i2293[0]
  i2292.yPlacement = i2293[1]
  i2292.xAdvance = i2293[2]
  i2292.yAdvance = i2293[3]
  return i2292
}

Deserializers["Dreamteck.Splines.SplineTrigger+TriggerEvent"] = function (request, data, root) {
  var i2294 = root || request.c( 'Dreamteck.Splines.SplineTrigger+TriggerEvent' )
  var i2295 = data
  i2294.m_PersistentCalls = request.d('UnityEngine.Events.PersistentCallGroup', i2295[0], i2294.m_PersistentCalls)
  return i2294
}

Deserializers.fields = {"Luna.Unity.DTO.UnityEngine.Assets.Material":{"name":0,"shader":1,"renderQueue":3,"enableInstancing":4,"floatParameters":5,"colorParameters":6,"vectorParameters":7,"textureParameters":8,"materialFlags":9},"Luna.Unity.DTO.UnityEngine.Assets.Material+FloatParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+ColorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+VectorParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+TextureParameter":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Material+MaterialFlag":{"name":0,"enabled":1},"Luna.Unity.DTO.UnityEngine.Textures.Texture2D":{"name":0,"width":1,"height":2,"mipmapCount":3,"anisoLevel":4,"filterMode":5,"hdr":6,"format":7,"wrapMode":8,"alphaIsTransparency":9,"alphaSource":10,"graphicsFormat":11,"sRGBTexture":12,"desiredColorSpace":13,"wrapU":14,"wrapV":15},"Luna.Unity.DTO.UnityEngine.Textures.Cubemap":{"name":0,"atlasId":1,"mipmapCount":2,"hdr":3,"size":4,"anisoLevel":5,"filterMode":6,"rects":7,"wrapU":8,"wrapV":9},"Luna.Unity.DTO.UnityEngine.Scene.Scene":{"name":0,"index":1,"startup":2},"Luna.Unity.DTO.UnityEngine.Components.Transform":{"position":0,"scale":3,"rotation":6},"Luna.Unity.DTO.UnityEngine.Scene.GameObject":{"name":0,"tagId":1,"enabled":2,"isStatic":3,"layer":4},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings":{"ambientIntensity":0,"reflectionIntensity":1,"ambientMode":2,"ambientLight":3,"ambientSkyColor":7,"ambientGroundColor":11,"ambientEquatorColor":15,"fogColor":19,"fogEndDistance":23,"fogStartDistance":24,"fogDensity":25,"fog":26,"skybox":27,"fogMode":29,"lightmaps":30,"lightProbes":31,"lightmapsMode":32,"mixedBakeMode":33,"environmentLightingMode":34,"ambientProbe":35,"referenceAmbientProbe":36,"useReferenceAmbientProbe":37,"customReflection":38,"defaultReflection":40,"defaultReflectionMode":42,"defaultReflectionResolution":43,"sunLightObjectId":44,"pixelLightCount":45,"defaultReflectionHDR":46,"hasLightDataAsset":47,"hasManualGenerate":48},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+Lightmap":{"lightmapColor":0,"lightmapDirection":2},"Luna.Unity.DTO.UnityEngine.Assets.RenderSettings+LightProbes":{"bakedProbes":0,"positions":1,"hullRays":2,"tetrahedra":3,"neighbours":4,"matrices":5},"Luna.Unity.DTO.UnityEngine.Components.RectTransform":{"pivot":0,"anchorMin":2,"anchorMax":4,"sizeDelta":6,"anchoredPosition3D":8,"rotation":11,"scale":15},"Luna.Unity.DTO.UnityEngine.Components.Canvas":{"enabled":0,"planeDistance":1,"referencePixelsPerUnit":2,"isFallbackOverlay":3,"renderMode":4,"renderOrder":5,"sortingLayerName":6,"sortingOrder":7,"scaleFactor":8,"worldCamera":9,"overrideSorting":11,"pixelPerfect":12,"targetDisplay":13,"overridePixelPerfect":14},"Luna.Unity.DTO.UnityEngine.Components.CanvasGroup":{"m_Alpha":0,"m_Interactable":1,"m_BlocksRaycasts":2,"m_IgnoreParentGroups":3,"enabled":4},"Luna.Unity.DTO.UnityEngine.Components.CanvasRenderer":{"cullTransparentMesh":0},"Luna.Unity.DTO.UnityEngine.Components.ParticleSystem":{"main":0,"colorBySpeed":1,"colorOverLifetime":2,"emission":3,"rotationBySpeed":4,"rotationOverLifetime":5,"shape":6,"sizeBySpeed":7,"sizeOverLifetime":8,"textureSheetAnimation":9,"velocityOverLifetime":10,"noise":11,"inheritVelocity":12,"forceOverLifetime":13,"limitVelocityOverLifetime":14,"useAutoRandomSeed":15,"randomSeed":16},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.MainModule":{"duration":0,"loop":1,"prewarm":2,"startDelay":3,"startLifetime":4,"startSpeed":5,"startSize3D":6,"startSizeX":7,"startSizeY":8,"startSizeZ":9,"startRotation3D":10,"startRotationX":11,"startRotationY":12,"startRotationZ":13,"startColor":14,"gravityModifier":15,"simulationSpace":16,"customSimulationSpace":17,"simulationSpeed":19,"useUnscaledTime":20,"scalingMode":21,"playOnAwake":22,"maxParticles":23,"emitterVelocityMode":24,"stopAction":25},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxCurve":{"mode":0,"curveMin":1,"curveMax":2,"curveMultiplier":3,"constantMin":4,"constantMax":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.MinMaxGradient":{"mode":0,"gradientMin":1,"gradientMax":2,"colorMin":3,"colorMax":7},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Gradient":{"mode":0,"colorKeys":1,"alphaKeys":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorBySpeedModule":{"enabled":0,"color":1,"range":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientColorKey":{"color":0,"time":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Data.GradientAlphaKey":{"alpha":0,"time":1},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ColorOverLifetimeModule":{"enabled":0,"color":1},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.EmissionModule":{"enabled":0,"rateOverTime":1,"rateOverDistance":2,"bursts":3},"Luna.Unity.DTO.UnityEngine.ParticleSystemTypes.Burst":{"count":0,"cycleCount":1,"minCount":2,"maxCount":3,"repeatInterval":4,"time":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationBySpeedModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4,"range":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.RotationOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ShapeModule":{"enabled":0,"shapeType":1,"randomDirectionAmount":2,"sphericalDirectionAmount":3,"randomPositionAmount":4,"alignToDirection":5,"radius":6,"radiusMode":7,"radiusSpread":8,"radiusSpeed":9,"radiusThickness":10,"angle":11,"length":12,"boxThickness":13,"meshShapeType":16,"mesh":17,"meshRenderer":19,"skinnedMeshRenderer":21,"useMeshMaterialIndex":23,"meshMaterialIndex":24,"useMeshColors":25,"normalOffset":26,"arc":27,"arcMode":28,"arcSpread":29,"arcSpeed":30,"donutRadius":31,"position":32,"rotation":35,"scale":38},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeBySpeedModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4,"range":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.SizeOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"separateAxes":4},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.TextureSheetAnimationModule":{"enabled":0,"mode":1,"animation":2,"numTilesX":3,"numTilesY":4,"useRandomRow":5,"frameOverTime":6,"startFrame":7,"cycleCount":8,"rowIndex":9,"flipU":10,"flipV":11,"spriteCount":12,"sprites":13},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.VelocityOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"radial":4,"speedModifier":5,"space":6,"orbitalX":7,"orbitalY":8,"orbitalZ":9,"orbitalOffsetX":10,"orbitalOffsetY":11,"orbitalOffsetZ":12},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.NoiseModule":{"enabled":0,"separateAxes":1,"strengthX":2,"strengthY":3,"strengthZ":4,"frequency":5,"damping":6,"octaveCount":7,"octaveMultiplier":8,"octaveScale":9,"quality":10,"scrollSpeed":11,"scrollSpeedMultiplier":12,"remapEnabled":13,"remapX":14,"remapY":15,"remapZ":16,"positionAmount":17,"rotationAmount":18,"sizeAmount":19},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.InheritVelocityModule":{"enabled":0,"mode":1,"curve":2},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.ForceOverLifetimeModule":{"enabled":0,"x":1,"y":2,"z":3,"space":4,"randomized":5},"Luna.Unity.DTO.UnityEngine.ParticleSystemModules.LimitVelocityOverLifetimeModule":{"enabled":0,"limit":1,"limitX":2,"limitY":3,"limitZ":4,"dampen":5,"separateAxes":6,"space":7,"drag":8,"multiplyDragByParticleSize":9,"multiplyDragByParticleVelocity":10},"Luna.Unity.DTO.UnityEngine.Components.ParticleSystemRenderer":{"enabled":0,"sharedMaterial":1,"sharedMaterials":3,"receiveShadows":4,"shadowCastingMode":5,"sortingLayerID":6,"sortingOrder":7,"lightmapIndex":8,"lightmapSceneIndex":9,"lightmapScaleOffset":10,"lightProbeUsage":14,"reflectionProbeUsage":15,"mesh":16,"meshCount":18,"activeVertexStreamsCount":19,"alignment":20,"renderMode":21,"sortMode":22,"lengthScale":23,"velocityScale":24,"cameraVelocityScale":25,"normalDirection":26,"sortingFudge":27,"minParticleSize":28,"maxParticleSize":29,"pivot":30,"trailMaterial":33},"Luna.Unity.DTO.UnityEngine.Assets.Mesh":{"name":0,"halfPrecision":1,"useUInt32IndexFormat":2,"vertexCount":3,"aabb":4,"streams":5,"vertices":6,"subMeshes":7,"bindposes":8,"blendShapes":9},"Luna.Unity.DTO.UnityEngine.Assets.Mesh+SubMesh":{"triangles":0},"Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShape":{"name":0,"frames":1},"Luna.Unity.DTO.UnityEngine.Components.Rigidbody":{"mass":0,"drag":1,"angularDrag":2,"useGravity":3,"isKinematic":4,"constraints":5,"maxAngularVelocity":6,"collisionDetectionMode":7,"interpolation":8},"Luna.Unity.DTO.UnityEngine.Components.BoxCollider":{"center":0,"size":3,"enabled":6,"isTrigger":7,"material":8},"Luna.Unity.DTO.UnityEngine.Components.MeshFilter":{"sharedMesh":0},"Luna.Unity.DTO.UnityEngine.Components.MeshRenderer":{"additionalVertexStreams":0,"enabled":2,"sharedMaterial":3,"sharedMaterials":5,"receiveShadows":6,"shadowCastingMode":7,"sortingLayerID":8,"sortingOrder":9,"lightmapIndex":10,"lightmapSceneIndex":11,"lightmapScaleOffset":12,"lightProbeUsage":16,"reflectionProbeUsage":17},"Luna.Unity.DTO.UnityEngine.Components.BoxCollider2D":{"usedByComposite":0,"autoTiling":1,"size":2,"edgeRadius":4,"enabled":5,"isTrigger":6,"usedByEffector":7,"density":8,"offset":9,"material":11},"Luna.Unity.DTO.UnityEngine.Components.Camera":{"enabled":0,"aspect":1,"orthographic":2,"orthographicSize":3,"backgroundColor":4,"nearClipPlane":8,"farClipPlane":9,"fieldOfView":10,"depth":11,"clearFlags":12,"cullingMask":13,"rect":14,"targetTexture":15,"usePhysicalProperties":17,"focalLength":18,"sensorSize":19,"lensShift":21,"gateFit":23,"commandBufferCount":24,"cameraType":25},"Luna.Unity.DTO.UnityEngine.Components.EdgeCollider2D":{"enabled":0,"isTrigger":1,"usedByEffector":2,"density":3,"offset":4,"material":6,"edgeRadius":8,"points":9,"useAdjacentStartPoint":10,"adjacentStartPoint":11,"useAdjacentEndPoint":13,"adjacentEndPoint":14},"Luna.Unity.DTO.UnityEngine.Components.Rigidbody2D":{"bodyType":0,"material":1,"simulated":3,"useAutoMass":4,"mass":5,"drag":6,"angularDrag":7,"gravityScale":8,"collisionDetectionMode":9,"sleepMode":10,"constraints":11},"Luna.Unity.DTO.UnityEngine.Components.CircleCollider2D":{"radius":0,"enabled":1,"isTrigger":2,"usedByEffector":3,"density":4,"offset":5,"material":7},"Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer":{"enabled":0,"sharedMaterial":1,"sharedMaterials":3,"receiveShadows":4,"shadowCastingMode":5,"sortingLayerID":6,"sortingOrder":7,"lightmapIndex":8,"lightmapSceneIndex":9,"lightmapScaleOffset":10,"lightProbeUsage":14,"reflectionProbeUsage":15,"sharedMesh":16,"bones":18,"updateWhenOffscreen":19,"localBounds":20,"rootBone":21,"blendShapesWeights":23},"Luna.Unity.DTO.UnityEngine.Components.SkinnedMeshRenderer+BlendShapeWeight":{"weight":0},"Luna.Unity.DTO.UnityEngine.Components.Animator":{"animatorController":0,"avatar":2,"updateMode":4,"hasTransformHierarchy":5,"applyRootMotion":6,"humanBones":7,"enabled":8},"Luna.Unity.DTO.UnityEngine.Assets.Mesh+BlendShapeFrame":{"weight":0,"vertices":1,"normals":2,"tangents":3},"Luna.Unity.DTO.UnityEngine.Components.TrailRenderer":{"enabled":0,"sharedMaterial":1,"sharedMaterials":3,"receiveShadows":4,"shadowCastingMode":5,"sortingLayerID":6,"sortingOrder":7,"lightmapIndex":8,"lightmapSceneIndex":9,"lightmapScaleOffset":10,"lightProbeUsage":14,"reflectionProbeUsage":15,"positions":16,"positionCount":17,"time":18,"startWidth":19,"endWidth":20,"widthMultiplier":21,"autodestruct":22,"emitting":23,"numCornerVertices":24,"numCapVertices":25,"minVertexDistance":26,"colorGradient":27,"startColor":28,"endColor":32,"generateLightingData":36,"textureMode":37,"alignment":38,"widthCurve":39},"Luna.Unity.DTO.UnityEngine.Components.Light":{"enabled":0,"type":1,"color":2,"cullingMask":6,"intensity":7,"range":8,"spotAngle":9,"shadows":10,"shadowNormalBias":11,"shadowBias":12,"shadowStrength":13,"shadowResolution":14,"lightmapBakeType":15,"renderMode":16,"cookie":17,"cookieSize":19},"Luna.Unity.DTO.UnityEngine.Components.AudioSource":{"clip":0,"outputAudioMixerGroup":2,"playOnAwake":4,"loop":5,"time":6,"volume":7,"pitch":8,"enabled":9},"Luna.Unity.DTO.UnityEngine.Assets.PhysicsMaterial2D":{"name":0,"bounciness":1,"friction":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader":{"ShaderCompilationErrors":0,"name":1,"guid":2,"shaderDefinedKeywords":3,"passes":4,"usePasses":5,"defaultParameterValues":6,"unityFallbackShader":7,"readDepth":9,"isCreatedByShaderGraph":10,"compiled":11},"Luna.Unity.DTO.UnityEngine.Assets.Shader+ShaderCompilationError":{"shaderName":0,"errorMessage":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass":{"id":0,"subShaderIndex":1,"name":2,"passType":3,"grabPassTextureName":4,"usePass":5,"zTest":6,"zWrite":7,"culling":8,"blending":9,"alphaBlending":10,"colorWriteMask":11,"offsetUnits":12,"offsetFactor":13,"stencilRef":14,"stencilReadMask":15,"stencilWriteMask":16,"stencilOp":17,"stencilOpFront":18,"stencilOpBack":19,"tags":20,"passDefinedKeywords":21,"passDefinedKeywordGroups":22,"variants":23,"excludedVariants":24,"hasDepthReader":25},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Value":{"val":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Blending":{"src":0,"dst":1,"op":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+StencilOp":{"pass":0,"fail":1,"zFail":2,"comp":3},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Tag":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+KeywordGroup":{"keywords":0,"hasDiscard":1},"Luna.Unity.DTO.UnityEngine.Assets.Shader+Pass+Variant":{"passId":0,"subShaderIndex":1,"keywords":2,"vertexProgram":3,"fragmentProgram":4,"exportedForWebGl2":5,"readDepth":6},"Luna.Unity.DTO.UnityEngine.Assets.Shader+UsePass":{"shader":0,"pass":2},"Luna.Unity.DTO.UnityEngine.Assets.Shader+DefaultParameterValue":{"name":0,"type":1,"value":2,"textureValue":6,"shaderPropertyFlag":7},"Luna.Unity.DTO.UnityEngine.Textures.Sprite":{"name":0,"texture":1,"aabb":3,"vertices":4,"triangles":5,"textureRect":6,"packedRect":10,"border":14,"transparency":18,"bounds":19,"pixelsPerUnit":20,"textureWidth":21,"textureHeight":22,"nativeSize":23,"pivot":25,"textureRectOffset":27},"Luna.Unity.DTO.UnityEngine.Assets.AudioClip":{"name":0},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip":{"name":0,"wrapMode":1,"isLooping":2,"length":3,"curves":4,"events":5,"halfPrecision":6,"_frameRate":7,"localBounds":8,"hasMuscleCurves":9,"clipMuscleConstant":10,"clipBindingConstant":11},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve":{"path":0,"hash":1,"componentType":2,"property":3,"keys":4,"objectReferenceKeys":5},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationCurve+ObjectReferenceKey":{"time":0,"value":1},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationEvent":{"functionName":0,"floatParameter":1,"intParameter":2,"stringParameter":3,"objectReferenceParameter":4,"time":6},"Luna.Unity.DTO.UnityEngine.Animation.Data.Bounds":{"center":0,"extends":3},"Luna.Unity.DTO.UnityEngine.Animation.Data.AnimationClip+AnimationClipBindingConstant":{"genericBindings":0,"pptrCurveMapping":1},"Luna.Unity.DTO.UnityEngine.Assets.Font":{"name":0,"ascent":1,"originalLineHeight":2,"fontSize":3,"characterInfo":4,"texture":5,"originalFontSize":7},"Luna.Unity.DTO.UnityEngine.Assets.Font+CharacterInfo":{"index":0,"advance":1,"bearing":2,"glyphWidth":3,"glyphHeight":4,"minX":5,"maxX":6,"minY":7,"maxY":8,"uvBottomLeftX":9,"uvBottomLeftY":10,"uvBottomRightX":11,"uvBottomRightY":12,"uvTopLeftX":13,"uvTopLeftY":14,"uvTopRightX":15,"uvTopRightY":16},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorController":{"name":0,"layers":1,"parameters":2,"animationClips":3,"avatarUnsupported":4},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerLayer":{"name":0,"defaultWeight":1,"blendingMode":2,"avatarMask":3,"syncedLayerIndex":4,"syncedLayerAffectsTiming":5,"syncedLayers":6,"stateMachine":7},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateMachine":{"id":0,"name":1,"path":2,"states":3,"machines":4,"entryStateTransitions":5,"exitStateTransitions":6,"anyStateTransitions":7,"defaultStateId":8},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorState":{"id":0,"name":1,"cycleOffset":2,"cycleOffsetParameter":3,"cycleOffsetParameterActive":4,"mirror":5,"mirrorParameter":6,"mirrorParameterActive":7,"motionId":8,"nameHash":9,"fullPathHash":10,"speed":11,"speedParameter":12,"speedParameterActive":13,"tag":14,"tagHash":15,"writeDefaultValues":16,"behaviours":17,"transitions":18},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorTransition":{"destinationStateId":0,"isExit":1,"mute":2,"solo":3,"conditions":4},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorStateTransition":{"fullPath":0,"canTransitionToSelf":1,"duration":2,"exitTime":3,"hasExitTime":4,"hasFixedDuration":5,"interruptionSource":6,"offset":7,"orderedInterruption":8,"destinationStateId":9,"isExit":10,"mute":11,"solo":12,"conditions":13},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorControllerParameter":{"defaultBool":0,"defaultFloat":1,"defaultInt":2,"name":3,"nameHash":4,"type":5},"Luna.Unity.DTO.UnityEngine.Assets.TextAsset":{"name":0,"bytes64":1,"data":2},"Luna.Unity.DTO.UnityEngine.Assets.Resources":{"files":0,"componentToPrefabIds":1},"Luna.Unity.DTO.UnityEngine.Assets.Resources+File":{"path":0,"unityObject":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings":{"scriptsExecutionOrder":0,"sortingLayers":1,"cullingLayers":2,"timeSettings":3,"physicsSettings":4,"physics2DSettings":5,"qualitySettings":6,"enableRealtimeShadows":7,"enableAutoInstancing":8,"enableDynamicBatching":9,"lightmapEncodingQuality":10,"desiredColorSpace":11,"allTags":12},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+ScriptsExecutionOrder":{"name":0,"value":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+SortingLayer":{"id":0,"name":1,"value":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+CullingLayer":{"id":0,"name":1},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+TimeSettings":{"fixedDeltaTime":0,"maximumDeltaTime":1,"timeScale":2,"maximumParticleTimestep":3},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings":{"gravity":0,"defaultSolverIterations":3,"bounceThreshold":4,"autoSyncTransforms":5,"autoSimulation":6,"collisionMatrix":7},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+PhysicsSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings":{"material":0,"gravity":2,"positionIterations":4,"velocityIterations":5,"velocityThreshold":6,"maxLinearCorrection":7,"maxAngularCorrection":8,"maxTranslationSpeed":9,"maxRotationSpeed":10,"baumgarteScale":11,"baumgarteTOIScale":12,"timeToSleep":13,"linearSleepTolerance":14,"angularSleepTolerance":15,"defaultContactOffset":16,"autoSimulation":17,"queriesHitTriggers":18,"queriesStartInColliders":19,"callbacksOnDisable":20,"reuseCollisionCallbacks":21,"autoSyncTransforms":22,"collisionMatrix":23},"Luna.Unity.DTO.UnityEngine.Assets.ProjectSettings+Physics2DSettings+CollisionMask":{"enabled":0,"layerId":1,"otherLayerId":2},"Luna.Unity.DTO.UnityEngine.Assets.QualitySettings":{"qualityLevels":0,"names":1,"shadows":2,"anisotropicFiltering":3,"antiAliasing":4,"lodBias":5,"shadowCascades":6,"shadowDistance":7,"shadowmaskMode":8,"shadowProjection":9,"shadowResolution":10,"softParticles":11,"softVegetation":12,"activeColorSpace":13,"desiredColorSpace":14,"masterTextureLimit":15,"maxQueuedFrames":16,"particleRaycastBudget":17,"pixelLightCount":18,"realtimeReflectionProbes":19,"shadowCascade2Split":20,"shadowCascade4Split":21,"streamingMipmapsActive":24,"vSyncCount":25,"asyncUploadBufferSize":26,"asyncUploadTimeSlice":27,"billboardsFaceCameraPosition":28,"shadowNearPlaneOffset":29,"streamingMipmapsMemoryBudget":30,"maximumLODLevel":31,"streamingMipmapsAddAllCameras":32,"streamingMipmapsMaxLevelReduction":33,"streamingMipmapsRenderersPerFrame":34,"resolutionScalingFixedDPIFactor":35,"streamingMipmapsMaxFileIORequests":36,"currentQualityLevel":37},"Luna.Unity.DTO.UnityEngine.Animation.Mecanim.AnimatorCondition":{"mode":0,"parameter":1,"threshold":2}}

Deserializers.requiredComponents = {"123":[124],"125":[124],"126":[124],"127":[124],"128":[124],"129":[124],"130":[82],"131":[60],"132":[53],"133":[53],"134":[53],"135":[53],"136":[53],"137":[53],"138":[53],"139":[71],"140":[71],"141":[71],"142":[71],"143":[71],"144":[71],"145":[71],"146":[71],"147":[71],"148":[71],"149":[71],"150":[71],"151":[71],"152":[60],"153":[52],"154":[155],"156":[155],"7":[6],"157":[158],"159":[160,60],"161":[158],"162":[160],"163":[164],"164":[160],"165":[158],"166":[158,163],"167":[158],"168":[158],"169":[160],"158":[160],"170":[158],"171":[158],"172":[158],"173":[158],"174":[12,35,6],"175":[176],"177":[10],"178":[13],"179":[13],"180":[58],"181":[6],"182":[6],"183":[6],"184":[6,7,9],"185":[27],"103":[102],"186":[187],"65":[67],"188":[56,52],"189":[190],"64":[56,52],"191":[56,52],"192":[56,52],"193":[56,52],"194":[56,52],"195":[6],"196":[52,6],"20":[6,12],"197":[6],"198":[12,6],"199":[52],"200":[12,6],"201":[6],"202":[203],"204":[205],"206":[207],"37":[6,12],"208":[207],"209":[71],"210":[53],"211":[71],"212":[213],"214":[71],"215":[60],"216":[53],"217":[71],"218":[203,6],"219":[203,6],"220":[203,6],"221":[203,6],"222":[203,6],"223":[203,6],"224":[203,6],"225":[203,6],"226":[203,6],"227":[203,6],"228":[203,6],"229":[99],"230":[60],"231":[56],"232":[56],"233":[53],"234":[71],"235":[6],"236":[53],"237":[238],"239":[240],"241":[92],"242":[6],"243":[12,6],"75":[52],"44":[12,6],"244":[83,52],"245":[52],"246":[52,56],"247":[53],"248":[71],"249":[250],"251":[252],"253":[12,6],"254":[60],"255":[6],"203":[6],"9":[7],"13":[12,6],"256":[6],"58":[7],"31":[6],"30":[6],"257":[6],"258":[6],"259":[6],"260":[6],"42":[6],"29":[6],"261":[6],"262":[12,6],"263":[6],"28":[6],"27":[6],"264":[6],"265":[12,6],"266":[6],"267":[92],"268":[92],"269":[92],"270":[92],"271":[60],"272":[60],"93":[92],"273":[7],"274":[60],"275":[90]}

Deserializers.types = ["UnityEngine.Shader","UnityEngine.Transform","UnityEngine.MonoBehaviour","ChallengeController","UnityEngine.Material","UnityEngine.Cubemap","UnityEngine.RectTransform","UnityEngine.Canvas","UnityEngine.EventSystems.UIBehaviour","UnityEngine.UI.GraphicRaycaster","UnityEngine.CanvasGroup","PopupBackground","UnityEngine.CanvasRenderer","UnityEngine.UI.Image","UnityEngine.Sprite","PopupChallenge","UnityEngine.GameObject","ChallengeConfig","LevelChallengeItem","MultipleChallengeItem","TMPro.TextMeshProUGUI","Crystal.SafeArea","ButtonCustom","UIEffect","TMPro.TMP_FontAsset","I2.Loc.Localize","I2.Loc.LocalizationParamsManager","UnityEngine.UI.ScrollRect","UnityEngine.UI.Scrollbar","UnityEngine.UI.Mask","UnityEngine.UI.GridLayoutGroup","UnityEngine.UI.ContentSizeFitter","RotateGameObject","UnityEngine.Texture2D","PopupInGame","UnityEngine.ParticleSystem","UnityEngine.ParticleSystemRenderer","Coffee.UIExtensions.UIParticle","UnityEngine.Mesh","PopupInGameChallenge","PopupIngameMultiple","PopupLose","UnityEngine.UI.VerticalLayoutGroup","BannerCollapsible","Spine.Unity.SkeletonGraphic","Spine.Unity.SkeletonDataAsset","PopupUI","CurrencyCounter","CurrencyGenerate","PopupWin","Level","BallHolder2D","UnityEngine.MeshRenderer","UnityEngine.Rigidbody","UnityEngine.BoxCollider","BallHolderSkin","UnityEngine.MeshFilter","UnityEngine.BoxCollider2D","UnityEngine.UI.CanvasScaler","Background","UnityEngine.Camera","BackgroundSkin","Destroyer","Dreamteck.Splines.SplineComputer","Dreamteck.Splines.SplineMesh","Dreamteck.Splines.EdgeColliderGenerator","Wall","UnityEngine.EdgeCollider2D","UnityEngine.PhysicsMaterial2D","PullingPin","PinSkin","UnityEngine.Rigidbody2D","Ball","BallSkin","UnityEngine.CircleCollider2D","Spine.Unity.SkeletonAnimation","TutorialGameObject","LevelChallenge","OutsideZone2D","OutsideZone3D","CameraChallenge","Bomb","UnityEngine.SkinnedMeshRenderer","UnityEngine.Animator","UnityEditor.Animations.AnimatorController","BombHandle","MultipleChallenge","PlusGate","MultipleGate","UnityEngine.TrailRenderer","UnityEngine.Light","UnityEngine.AudioListener","UnityEngine.EventSystems.EventSystem","UnityEngine.InputSystem.UI.InputSystemUIInputModule","UnityEngine.InputSystem.InputActionAsset","UnityEngine.InputSystem.InputActionReference","GameManager","LevelController","IconDataConfig","Lean.Touch.LeanTouch","PopupController","SoundController","Pancake.Notification.GameNotificationsManager","Pancake.Notification.NotificationConsole","ConfigController","GameConfig","SoundConfig","ItemConfig","GameEventConfig","UnityEngine.AudioSource","CameraUIController","VFXSpawnController","LoadingController","OdeeoManager","AdjustController","UnityEngine.Font","Spine.Unity.SpineAtlasAsset","UnityEngine.TextAsset","UnityEngine.AudioClip","DG.Tweening.Core.DOTweenSettings","TMPro.TMP_Settings","TMPro.TMP_SpriteAsset","TMPro.TMP_StyleSheet","UnityEngine.AudioLowPassFilter","UnityEngine.AudioBehaviour","UnityEngine.AudioHighPassFilter","UnityEngine.AudioReverbFilter","UnityEngine.AudioDistortionFilter","UnityEngine.AudioEchoFilter","UnityEngine.AudioChorusFilter","UnityEngine.Cloth","UnityEngine.FlareLayer","UnityEngine.ConstantForce","UnityEngine.Joint","UnityEngine.HingeJoint","UnityEngine.SpringJoint","UnityEngine.FixedJoint","UnityEngine.CharacterJoint","UnityEngine.ConfigurableJoint","UnityEngine.CompositeCollider2D","UnityEngine.Joint2D","UnityEngine.AnchoredJoint2D","UnityEngine.SpringJoint2D","UnityEngine.DistanceJoint2D","UnityEngine.FrictionJoint2D","UnityEngine.HingeJoint2D","UnityEngine.RelativeJoint2D","UnityEngine.SliderJoint2D","UnityEngine.TargetJoint2D","UnityEngine.FixedJoint2D","UnityEngine.WheelJoint2D","UnityEngine.ConstantForce2D","UnityEngine.StreamingController","UnityEngine.TextMesh","UnityEngine.Tilemaps.TilemapRenderer","UnityEngine.Tilemaps.Tilemap","UnityEngine.Tilemaps.TilemapCollider2D","UnityMovementAI.GoDirectionUnit","UnityMovementAI.SteeringBasics","UnityMovementAI.ThirdPersonUnit","UnityMovementAI.MovementAIRigidbody","UnityMovementAI.Cohesion","UnityMovementAI.CollisionAvoidance","UnityMovementAI.Evade","UnityMovementAI.Flee","UnityMovementAI.FollowPath","UnityMovementAI.Hide","UnityMovementAI.OffsetPursuit","UnityMovementAI.Pursue","UnityMovementAI.Separation","UnityMovementAI.VelocityMatch","UnityMovementAI.WallAvoidance","UnityMovementAI.Wander1","UnityMovementAI.Wander2","UnityEngine.UI.Extensions.UIParticleSystem","Pancake.LineRendererSmooth","UnityEngine.LineRenderer","Pancake.Loader.LoadingComponent","Pancake.UI.UIButton","Pancake.UI.UIButtonTMP","Pancake.UI.CanvasResizer","Pancake.UI.FixedJoystick","Pancake.UI.FloatingJoystick","Pancake.UI.Joystick","Pancake.UI.UIPopup","Pancake.UI.EnhancedScroller","Pancake.EventBus.SignalReceiverListener","UnityEngine.Timeline.SignalReceiver","Dreamteck.Splines.PathGenerator","Dreamteck.Splines.PolygonColliderGenerator","UnityEngine.PolygonCollider2D","Dreamteck.Splines.SplineRenderer","Dreamteck.Splines.SurfaceGenerator","Dreamteck.Splines.TubeGenerator","Dreamteck.Splines.WaveformGenerator","TMPro.TextContainer","TMPro.TextMeshPro","TMPro.TMP_Dropdown","TMPro.TMP_SelectionCaret","TMPro.TMP_SubMesh","TMPro.TMP_SubMeshUI","TMPro.TMP_Text","Lean.Common.LeanSelectableGraphicColor","UnityEngine.UI.Graphic","Lean.Common.LeanSelectableRendererColor","UnityEngine.Renderer","Lean.Common.LeanSelectableSpriteRendererColor","UnityEngine.SpriteRenderer","UnityEngine.U2D.Animation.SpriteSkin","Lean.Common.LeanPongBall","Lean.Common.LeanChaseRigidbody","Lean.Common.LeanChaseRigidbody2D","Lean.Common.LeanPitchYawAutoRotate","Lean.Common.LeanPitchYaw","Lean.Common.LeanRotateToRigidbody2D","ToonyColorsPro.Runtime.TCP2_CameraDepth","Lean.Pool.LeanPooledRigidbody","Lean.Pool.LeanPooledRigidbody2D","Coffee.UIEffects.BaseMaterialEffect","Coffee.UIEffects.BaseMeshEffect","Coffee.UIEffects.UIDissolve","Coffee.UIEffects.UIEffect","Coffee.UIEffects.UIFlip","Coffee.UIEffects.UIGradient","Coffee.UIEffects.UIHsvModifier","Coffee.UIEffects.UIShadow","Coffee.UIEffects.UIShiny","Coffee.UIEffects.UISyncEffect","Coffee.UIEffects.UITransitionEffect","Lean.Touch.LeanTouchSimulator","UnityEngine.Rendering.PostProcessing.PostProcessLayer","Lean.Touch.LeanDragColorMesh","Lean.Touch.LeanDragDeformMesh","Lean.Touch.LeanDragTranslateRigidbody","Lean.Touch.LeanDragTranslateRigidbody2D","Lean.Touch.LeanFingerDownCanvas","Lean.Touch.LeanSelectableDragTorque","UnityEngine.Purchasing.IAPButton","UnityEngine.UI.Button","UnityEngine.U2D.SpriteShapeController","UnityEngine.U2D.SpriteShapeRenderer","AppLovinMax.Scripts.MaxEventSystemChecker","Spine.Unity.BoneFollowerGraphic","Spine.Unity.SkeletonSubmeshGraphic","Spine.Unity.SkeletonMecanim","Spine.Unity.SkeletonRenderer","Spine.Unity.SkeletonPartsRenderer","Spine.Unity.FollowLocationRigidbody","Spine.Unity.FollowLocationRigidbody2D","Spine.Unity.SkeletonUtility","Spine.Unity.ISkeletonAnimation","Spine.Unity.SkeletonUtilityConstraint","Spine.Unity.SkeletonUtilityBone","TCP2_Demo_InvertedMaskImage","Kino.Bloom","UnityEngine.UI.Dropdown","UnityEngine.UI.AspectRatioFitter","UnityEngine.UI.HorizontalLayoutGroup","UnityEngine.UI.HorizontalOrVerticalLayoutGroup","UnityEngine.UI.LayoutElement","UnityEngine.UI.LayoutGroup","UnityEngine.UI.MaskableGraphic","UnityEngine.UI.RawImage","UnityEngine.UI.RectMask2D","UnityEngine.UI.Slider","UnityEngine.UI.Text","UnityEngine.UI.Toggle","UnityEngine.EventSystems.BaseInputModule","UnityEngine.EventSystems.PointerInputModule","UnityEngine.EventSystems.StandaloneInputModule","UnityEngine.EventSystems.TouchInputModule","UnityEngine.EventSystems.Physics2DRaycaster","UnityEngine.EventSystems.PhysicsRaycaster","UnityEngine.InputSystem.UI.TrackedDeviceRaycaster","CW.Common.CwDepthTextureMode","CW.Common.CwLightIntensity"]

Deserializers.unityVersion = "2022.3.41f1";

Deserializers.productName = "Pull Pin Out 3D";

Deserializers.lunaInitializationTime = "12/06/2024 09:48:32";

Deserializers.lunaDaysRunning = "0.0";

Deserializers.lunaVersion = "6.2.0";

Deserializers.lunaSHA = "7963e9fed253d218ae1c5298f104efd7e457ea14";

Deserializers.creativeName = "";

Deserializers.lunaAppID = "25626";

Deserializers.projectId = "7596c2d3aeed1ab44af139fc0e5d1329";

Deserializers.packagesInfo = "com.unity.inputsystem: 1.7.0\ncom.unity.postprocessing: 3.4.0\ncom.unity.textmeshpro: 3.0.6\ncom.unity.timeline: 1.7.6\ncom.unity.ugui: 1.0.0";

Deserializers.externalJsLibraries = "";

Deserializers.androidLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.androidLink?window.$environment.packageConfig.androidLink:'Empty';

Deserializers.iosLink = ( typeof window !== "undefined")&&window.$environment.packageConfig.iosLink?window.$environment.packageConfig.iosLink:'Empty';

Deserializers.base64Enabled = "False";

Deserializers.minifyEnabled = "True";

Deserializers.isForceUncompressed = "False";

Deserializers.isAntiAliasingEnabled = "False";

Deserializers.isRuntimeAnalysisEnabledForCode = "False";

Deserializers.runtimeAnalysisExcludedClassesCount = "0";

Deserializers.runtimeAnalysisExcludedMethodsCount = "0";

Deserializers.runtimeAnalysisExcludedModules = "";

Deserializers.isRuntimeAnalysisEnabledForShaders = "True";

Deserializers.isRealtimeShadowsEnabled = "False";

Deserializers.isReferenceAmbientProbeBaked = "False";

Deserializers.isLunaCompilerV2Used = "False";

Deserializers.companyName = "Guardian.Of.Gods";

Deserializers.buildPlatform = "Android";

Deserializers.applicationIdentifier = "com.gamee.pull.pin.puzzle";

Deserializers.disableAntiAliasing = true;

Deserializers.graphicsConstraint = 28;

Deserializers.linearColorSpace = false;

Deserializers.buildID = "55a068e6-ac69-4973-974a-15bd5fe862ba";

Deserializers.runtimeInitializeOnLoadInfos = [[["CW","Common","CwInput","Enable"],["Unity","Services","Core","Internal","UnityServicesInitializer","EnableServicesInitializationAsync"],["MaxSdkUnityEditor","InitializeMaxSdkUnityEditorOnLoad"],["UnityEngine","Purchasing","CodelessIAPStoreListener","InitializeCodelessPurchasingOnLoad"],["Coffee","UIExtensions","UIParticleUpdater","InitializeOnLoad"],["Animancer","Validate","InitializePermanentlyDisabledWarnings"],["Pancake","Runtime","AutoInitialize"],["UnityEngine","Experimental","Rendering","ScriptableRuntimeReflectionSystemSettings","ScriptingDirtyReflectionSystemInstance"]],[["Unity","Services","Core","Registration","CorePackageInitializer","InitializeOnLoad"],["UnityEngine","InputSystem","InputSystem","RunInitialUpdate"],["Unity","Services","Core","Internal","TaskAsyncOperation","SetScheduler"],["Coffee","UIEffects","GraphicConnector","Init"],["Ua2CoreInitializeCallback","Register"],["Unity","Services","Core","Environments","Client","Scheduler","EngineStateHelper","Init"],["Unity","Services","Core","Environments","Client","Scheduler","ThreadHelper","Init"],["Pancake","GameService","LoginResultModel","Setup"],["Pancake","VariableFrameRatePhysicsSystem","Initialize"],["Pancake","Threading","Tasks","PlayerLoopHelper","Init"],["Pancake","UI","Popup","Initialize"],["Pancake","EventBus","GlobalBus","_domainReloadCapability"],["Pancake","OdinSerializer","Utilities","UnityVersion","EnsureLoaded"],["Pancake","OdinSerializer","UnitySerializationInitializer","InitializeRuntime"],["UnityEngine","Purchasing","Registration","IapCoreInitializeCallback","Register"],["I2","Loc","LocalizeTarget_TextMeshPro_Label","AutoRegister"],["I2","Loc","LocalizeTarget_UnityUI_RawImage","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_Prefab","AutoRegister"],["I2","Loc","LocalizeTarget_TextMeshPro_UGUI","AutoRegister"],["I2","Loc","LocalizeTarget_UnityUI_Text","AutoRegister"],["I2","Loc","LocalizeTarget_UnityUI_Image","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_MeshRenderer","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_SpriteRenderer","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_VideoPlayer","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_TextMesh","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_AudioSource","AutoRegister"],["I2","Loc","LocalizeTarget_UnityStandard_Child","AutoRegister"]],[["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["Unity","Services","Core","Internal","UnityServicesInitializer","CreateStaticInstance"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"],["$BurstDirectCallInitializer","Initialize"]],[["Unity","Services","Core","Environments","Client","Http","JsonHelpers","RegisterTypesForAOT"]],[["UnityEngine","InputSystem","InputSystem","RunInitializeInPlayer"],["Spine","Unity","AttachmentTools","AtlasUtilities","Init"],["MaxSdkCallbacks","ResetOnDomainReload"],["Unity","Services","Core","UnityThreadUtils","CaptureUnityThreadInfo"]]];

Deserializers.typeNameToIdMap = function(){ var i = 0; return Deserializers.types.reduce( function( res, item ) { res[ item ] = i++; return res; }, {} ) }()

