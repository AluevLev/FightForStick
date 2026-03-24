using IceFebruary;
using IceFebruary.Space.Follow;

public class FaceHandler : ITogglable
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
	public void SetStartFace()
	{
        if (!Enabled)
            return;

        _facialExpression.ChangeFace(_grimaceLibrary.DefaultFace);
	}
	public void FaceFollowTarget()
	{
		if (!Enabled)
			return;

		_faceFollower.Follow();
	}
}
