using UnityEngine;

public class SpringArm : MonoBehaviour
{
	[SerializeField] Camera cam = null;
	[SerializeField] Vector3 offsetSpringArmPivot = Vector3.zero;
	[SerializeField] float armLength = 10f;
	[SerializeField] float offsetHeight = 10f;

	float angle = 0;

	public Camera Cam => cam;
	public Vector3 CamWithoutRotation => cam.transform.eulerAngles = Vector3.zero;
	public Vector3 CenterCharacter => transform.parent.position + offsetSpringArmPivot;

	//public Vector3 OffsetHeight => new Vector3(0, offsetHeight, 0);

	public Vector3 FinalCameraPosition => GetRotateCamera(angle);

	private void Start()
	{
		UpdateCameraPosition();
	}
	private void LateUpdate()
	{
		UpdateCameraPosition();
		cam.transform.LookAt(transform.position);
		//Debug.Log($"Distance: {Vector3.Distance(CenterCharacter, GetFinalPosition(angle))}");
	}

	private void UpdateCameraPosition()
	{
		if (!cam) return;
		cam.transform.position = GetRotateCamera(angle); // + new Vector3(0, offsetHeight, 0);
	}
	float CameraAlpha()
	{
		bool _result = Physics.Raycast(new Ray(CenterCharacter, transform.position + transform.forward * -armLength),
		out RaycastHit _hitInfo, armLength);
		return _result ? (_hitInfo.distance / armLength) : 1;
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		bool _result = Physics.Raycast(new Ray(transform.position, FinalCameraPosition),
		out RaycastHit _hitInfo, armLength);
		float _alpha = _result ? (_hitInfo.distance / armLength) : 1;
		Gizmos.DrawLine(CenterCharacter, Vector3.Lerp(CenterCharacter, FinalCameraPosition, _alpha));
		Gizmos.DrawWireSphere(Vector3.Lerp(CenterCharacter, FinalCameraPosition, _alpha) + new Vector3(0, offsetHeight, 0), .5f);

		Gizmos.color = Color.white;
	}

	public void SetRotateSpring(float _angle = 0)
	{
		angle = ClampAngle(_angle);
		angle = _angle;
	}

	private Vector3 GetRotateCamera(float _angle = 0)
	{
		float _x = Mathf.Cos(_angle * Mathf.Deg2Rad) * armLength,
			_y = Mathf.Sin(_angle * Mathf.Deg2Rad) * armLength;

		Vector3 _pos = new Vector3(_x, 0, _y);

		bool _result = Physics.Raycast(new Ray(transform.position, _pos), out RaycastHit _hitInfo, armLength);

		if (_result)
			return _hitInfo.point + new Vector3(0, 1, 0);
		return CenterCharacter + _pos;
	}

	float ClampAngle(float _angle)
	{
		float _ang = _angle % 360f;
		return _ang;
	}
}