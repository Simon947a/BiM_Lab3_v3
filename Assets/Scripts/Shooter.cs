using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public  Rigidbody projectile;
	public Transform shotPos;
    public float shotForce = 3000f;
	public float moveSpeed = 10f;
	public float jumpHeight = 2000f;

    Rigidbody rgbd;

	void Start(){
		rgbd = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

        shotForce = Random.Range(1000, 5000);
        jumpHeight = Random.Range(1000, 5000);

    float h = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float v = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;

		float jump = 0.0f;
		if(Input.GetButtonDown("Jump")){
			jump = jumpHeight * Time.deltaTime * moveSpeed;
			rgbd.AddForce(new Vector3(0,jump,0));
		}
		transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime);
		transform.Translate (new Vector3 (h, 0, v));

		// Create some bullets
		if (Input.GetButtonUp ("Fire1")) {
			Rigidbody shot = Instantiate(projectile,shotPos.position,shotPos.rotation) as Rigidbody;
			shot.AddForce(shotPos.forward * shotForce);
		}
	}
}
