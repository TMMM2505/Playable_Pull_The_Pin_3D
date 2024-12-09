#import "OdeeoSdkManagerListener.h"

@implementation OdeeoSdkManagerListener 

-(instancetype) initWithListenersOnInitialization:(POTypeCallbackClientRef* )client with:(OdeeoSdkNoArgsDelegateNative)onInitializationSuccessRef and:(OdeeoSdkNoArgsDelegateNative)onInitializationFailedRef
{
    self = [super init];
    _clientRef = client;
    _onInitializationSuccessCallback = onInitializationSuccessRef;
    _onInitializationFailedCallback = onInitializationFailedRef;
    return self;
}

#pragma mark - PlayOnManagerListener

-(void) onInitializationSuccess{
    _onInitializationSuccessCallback(_clientRef);
}

- (void)onInitializationFailed { 
    _onInitializationFailedCallback(_clientRef);
}

@end
