#import <OdeeoSDK/OdeeoSDK-Swift.h>
#import "OdeeoSdkAdListener.h"

typedef void (*OdeeoSdkVoidDelegateNative) ();

@interface OdeeoSdkManagerListener: NSObject <OdeeoDelegate> {
    OdeeoSdkNoArgsDelegateNative _onInitializationSuccessCallback;
    OdeeoSdkNoArgsDelegateNative _onInitializationFailedCallback;
    POTypeCallbackClientRef* _clientRef;
}

-(instancetype) initWithListenersOnInitialization:(POTypeCallbackClientRef* )client with:(OdeeoSdkNoArgsDelegateNative)onInitializationSuccessRef and:(OdeeoSdkNoArgsDelegateNative)onInitializationFailedRef;

- (void)onInitializationSuccess;
- (void)onInitializationFailed;


@end
