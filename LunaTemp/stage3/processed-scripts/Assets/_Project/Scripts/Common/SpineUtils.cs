using Spine.Unity;

public static class SpineUtils
{
    public static void PlayAnim(this SkeletonAnimation animator, string animName, bool loop, float timeScale = 1,
        int trackIndex = 0)
    {
        if (!animator || animName == "") return;
        animator.Skeleton.SetToSetupPose();
        animator.timeScale = timeScale;
        animator.AnimationState.SetAnimation(trackIndex, animName, loop);
        animator.AnimationState.Apply(animator.Skeleton);
    }

    public static void PlayAnim(this SkeletonAnimation animator, string[] animNames, float timeScale = 1,
        int trackIndex = 0)
    {
        if (!animator || animNames.Length <= 0) return;
        animator.Skeleton.SetToSetupPose();
        animator.timeScale = timeScale;
        for (var i = 0; i < animNames.Length; i++)
        {
            var animName = animNames[i];
            if (animName == "") continue;
            if (i == 0) animator.AnimationState.SetAnimation(trackIndex, animName, animNames.Length == 1);
            else animator.AnimationState.AddAnimation(trackIndex, animName, i == animNames.Length - 1, 0f);
        }

        animator.AnimationState.Apply(animator.Skeleton);
    }


    public static void PlayAnim(this SkeletonGraphic animator, string animName, bool loop, float timeScale = 1,
        int trackIndex = 0)
    {
        if (!animator || animName == "") return;
        animator.Skeleton.SetToSetupPose();
        animator.timeScale = timeScale;
        animator.AnimationState.SetAnimation(trackIndex, animName, loop);
        animator.AnimationState.Apply(animator.Skeleton);
    }

    public static void PlayAnim(this SkeletonGraphic animator, string[] animNames, float timeScale = 1,
        int trackIndex = 0)
    {
        if (!animator || animNames.Length <= 0) return;
        animator.Skeleton.SetToSetupPose();
        animator.timeScale = timeScale;
        for (var i = 0; i < animNames.Length; i++)
        {
            var animName = animNames[i];
            if (animName == "") continue;
            if (i == 0) animator.AnimationState.SetAnimation(trackIndex, animName, animNames.Length == 1);
            else animator.AnimationState.AddAnimation(trackIndex, animName, i == animNames.Length - 1, 0f);
        }

        animator.AnimationState.Apply(animator.Skeleton);
    }

    public static float GetAnimationDuration(this SkeletonAnimation animator, string animName)
    {
        if (!animator || animName == "") return 0;

        var anim = animator.skeleton.Data.FindAnimation(animName);
        if (anim != null) return anim.Duration;

        return 0;
    }


    public static float GetAnimationDuration(this SkeletonGraphic animator, string animName)
    {
        if (!animator || animName == "") return 0;

        var anim = animator.SkeletonData.FindAnimation(animName);
        if (anim != null) return anim.Duration;

        return 0;
    }
}