using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileTile : Tile {
	[Header("Sound Effects")]
	[SerializeField] AudioClip CrumbleSound;
	[SerializeField] AudioClip BreakSound;
	[SerializeField] List<Rigidbody> CrumblingParts = new List<Rigidbody>();
	[SerializeField] List<Rigidbody> BreakingParts = new List<Rigidbody>();

	new private Collider collider;
	private AudioSource audioSource;
	private ParticleSystem crumbles;

	void Start () {
		collider = GetComponent<Collider>();
		audioSource = GetComponent<AudioSource>();
		crumbles = GetComponentInChildren<ParticleSystem>();
	}

	override public void Enter(Player player) {
		audioSource.PlayOneShot(CrumbleSound);
		crumbles.Play();
		foreach(Rigidbody part in CrumblingParts) {
			part.isKinematic = false;
			part.AddTorque(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
			Destroy(part.gameObject, 5f);
		}
	}

	override public void Leave(Player player) {
		audioSource.PlayOneShot(BreakSound);
		collider.enabled = false;
		foreach(Rigidbody part in BreakingParts) {
			part.isKinematic = false;
			part.AddTorque(Random.Range(-100f, 100f), 0f, Random.Range(-100f, 100f));
			Destroy(part.gameObject, 5f);
		}
	}
}
