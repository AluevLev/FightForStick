using IceFebruary.Space.Follow;

public class FaceHandler
{
	private readonly GrimaceLibrary _grimaceLibrary;

	private readonly IFacialExpression _facialExpression;
	private readonly ITransformFollower _faceFollower;
	public FaceHandler(IFacialExpression facialExpression, ITransformFollower transformFollower, GrimaceLibrary grimaceLibrary)
	{
		_facialExpression = facialExpression;
		_faceFollower = transformFollower;
		_grimaceLibrary = grimaceLibrary;
	}
    public void SetStartFace()
	{
        _facialExpression.ChangeFace(_grimaceLibrary.DefaultFace);
	}
	public void FaceFollowTarget()
	{
		_faceFollower.Follow();
	}
}
