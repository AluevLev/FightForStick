using VContainer.Unity;
using IceFebruary;
using IceFebruary.Space.Follow;
public class FaceHandler : ITogglable, ITickable, IInitializable
{
	private readonly GrimaceLibrary _grimaceLibrary;

	private readonly IFacialExpression _facialExpression;
	private readonly ITransformFollower _faceFollower;

	public bool Enabled { get; set; } = true;
	public FaceHandler(IFacialExpression facialExpression, ITransformFollower transformFollower, GrimaceLibrary grimaceLibrary)
	{
		_facialExpression = facialExpression;
		_faceFollower = transformFollower;
		_grimaceLibrary = grimaceLibrary;
	}
	public void Initialize()
	{
		SetStartFace();
	}
	public void Tick()
	{
		FaceFollowTarget();
	}
	private void SetStartFace()
	{
        if (!Enabled)
            return;

        _facialExpression.ChangeFace(_grimaceLibrary.DefaultFace);
	}
	private void FaceFollowTarget()
	{
		if (!Enabled)
			return;

		_faceFollower.Follow();
	}
}
