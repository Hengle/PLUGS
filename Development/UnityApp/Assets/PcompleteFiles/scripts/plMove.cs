using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class plMove : Photon.MonoBehaviour {

	private Vector3 selfPos;

	private GameObject sceneCam;

	[Header("General Booleans")]
	public bool devTesting = false;
	public bool isGrounded = false;
    public bool disableMove = false;

	[Space]
	[Header("General Floats/Ints")]
	public float moveSpeed = 100f;
	public float jumpForce = 800f;

	[Space]
	public Color enemeyTextColor;

    public TextMesh plName;
	public Text playerName;

	public PhotonView photonView;

	public SpriteRenderer sprite;

	public Rigidbody2D rigidBody;

	//public GameObject plCam;

	public GameObject bulletPrefab;



	private void Awake(){
		if (!devTesting && photonView.isMine) {
			//sceneCam = GameObject.Find ("Main Camera");
			//sceneCam.SetActive (false);
			//plCam.SetActive (true);
			playerName.text = PhotonNetwork.playerName;
		}


		if (!devTesting && !photonView.isMine) {
			playerName.text = photonView.owner.name;
			playerName.color = enemeyTextColor;
		}
	}

	private void Update(){

		if (!devTesting) {
			if (photonView.isMine)
				checkInput ();
			else
				smoothNetMovement ();
		} else
			checkInput ();

	}


	private void checkInput(){
        if(!disableMove)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0);
            transform.position += move * moveSpeed * Time.deltaTime;


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                prefromJump();
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                sprite.flipX = false;

                if (!devTesting)
                    photonView.RPC("onSpriteFlipFalse", PhotonTargets.Others);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                sprite.flipX = true;

                if (!devTesting)
                    photonView.RPC("onSpriteFlipTrue", PhotonTargets.Others);
            }


            if (Input.GetKeyDown(KeyCode.Q))
            {
                shooting();
            }
        }

	}



	void shooting()
	{
		if (!devTesting) {
			if (sprite.flipX == false) {
				GameObject obj = PhotonNetwork.Instantiate (bulletPrefab.name, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity, 0);

			} else {
				GameObject obj = PhotonNetwork.Instantiate (bulletPrefab.name, new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity, 0);
				obj.GetComponent<PhotonView> ().RPC ("changeDirection_Left", PhotonTargets.AllBuffered);
			}

		}
	}





	void prefromJump(){
		rigidBody.AddForce (Vector2.up * jumpForce);
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (!devTesting) {
			if (photonView.isMine) {
				if (coll.gameObject.tag == "Ground")
					isGrounded = true;
			}
		} else {
			if (coll.gameObject.tag == "Ground")
				isGrounded = true;
		}
	}


	void OnCollisionExit2D(Collision2D coll) {
		if (!devTesting) {
			if (photonView.isMine) {
				if (coll.gameObject.tag == "Ground")
					isGrounded = false;
			}
		} else {
			if (coll.gameObject.tag == "Ground")
				isGrounded = false;
		}
	}










	/// <summary>
	/// ///////////////////// NET CODE
	/// </summary>


	[PunRPC]
	private void onSpriteFlipTrue(){
		sprite.flipX = true;
	}

	[PunRPC]
	private void onSpriteFlipFalse(){
		sprite.flipX = false;
	}


	private void smoothNetMovement(){
		//transform.position = Vector3.Lerp (transform.position, selfPos, Time.deltaTime * 8);
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{

		if (stream.isWriting) {
			//stream.SendNext (transform.position);
		} else {
			//selfPos = (Vector3)stream.ReceiveNext ();
		}

	}


}
