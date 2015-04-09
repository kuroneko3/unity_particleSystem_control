/*
 * unity用.
 * githubのテスト用スクリプト.
 * 
 * 特に使う意味もない.
 * 
*/

using UnityEngine;
using System.Collections;

class Eff_ParticleSystem_UploadTest : MonoBehaviour {

	private ParticleSystem m_particleSystem = null;

	private ParticleSystem.Particle[] m_particles = null;

	void Start () {

		m_particleSystem = this.gameObject.particleSystem;

		m_particles = new ParticleSystem.Particle[50];
	}

	void extendArrayLength ( ParticleSystem particleSystem ) {

		if ( particleSystem == null ) {
			return;
		}

		if ( m_particles == null || particleSystem.particleCount > m_particles.Length ) {
			m_particles = new ParticleSystem.Particle[particleSystem.particleCount];
		}
	}

	void updateParticleSystem ( ParticleSystem particleSystem ) {

		if ( particleSystem == null ) {
			return;
		}

		extendArrayLength ( particleSystem );

		int count = particleSystem.particleCount;
		particleSystem.GetParticles ( m_particles );

		//	無駄にy方向に動かしてみる.
		//	回転軸と角度を与えた場合,現在の角度に加算されるのか書き換えられるのか.
		//	後者ならQuaternionでも良いような気もする.
		for ( int i = 0;i < count; ++i ) {
			m_particles[i].position += new Vector3 ( 0.0f, 1.0f, 0.0f );
		//	m_particles[i].axisOfRotation = new Vector3 ( 0.0f, 1.0f, 0.0f );
		//	m_particles[i].rotation = new Vector3 ( 90.0f );
		}

		particleSystem.SetParticles ( m_particles, count );
	}

	void Update () {

		updateParticleSystem ( m_particleSystem );
	}

};
