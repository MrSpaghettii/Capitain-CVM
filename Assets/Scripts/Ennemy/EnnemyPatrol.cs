﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnnemyPatrol : MonoBehaviour
{
    /// <summary>
    /// Vitesse de l'objet en patrouille
    /// </summary>
    [SerializeField]
    private float _vitesse = 8f;
    /// <summary>
    /// Liste de GO représentant les points à atteindre
    /// </summary>
    [SerializeField]
    private Transform[] _points;
    /// <summary>
    /// Référence vers la cible actuelle de l'objet
    /// </summary>
    private Transform _cible = null;
    /// <summary>
    /// Permet de connaître la position actuelle de la cible dans le tableau
    /// </summary>
    private int _indexPoint;
    /// <summary>
    /// Seuil où l'objet change de cible de déplacement
    /// </summary>
    private float _distanceSeuil = 0.3f;
    /// <summary>
    /// Référence vers le sprite Renderer
    /// </summary>
    private SpriteRenderer _sr;

    private float _y = -1;
    private float _degrees = 0.0f;
    private bool _rotationFlip = false;
    private string _spriteName;
    
    // Start is called before the first frame update
    void Start()
    {
        _sr = this.GetComponent<SpriteRenderer>();
        _spriteName = this.GetComponent<SpriteRenderer>().sprite.name;
        _indexPoint = 0;
        _cible = _points[_indexPoint];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _cible.position - this.transform.position;
        this.transform.Translate(direction.normalized * _vitesse * Time.deltaTime, Space.World);

        //Pour augmenter et duminuer l'axe des y + un flip hehe
        if (_spriteName == "ufo") 
        { 
            Vector3 vole = transform.position;
        
            if (vole.y > 1)
            {
                _y = -0.01f;
            }
            else if (vole.y < -1)
            {
                _y = 0.01f;
            }
            vole.y += _y;

            if (_rotationFlip == true) {
                _degrees += 1;
                transform.eulerAngles = new Vector3(0,0,_degrees);
                if (_degrees > 360) 
                { 
                    _rotationFlip = false;
                    _degrees = 0;
                    transform.eulerAngles = new Vector3(0, 0, _degrees);
                }
            }
            transform.position = vole;
        }


            if (direction.x < 0 && !_sr.flipX) _sr.flipX = true;
        else if (direction.x > 0 && _sr.flipX) {
            _sr.flipX = false;
            _rotationFlip = true;

        } 
        

        if (Vector3.Distance(this.transform.position, _cible.position) < _distanceSeuil)
        {
            _indexPoint = (++_indexPoint) % _points.Length;
            _cible = _points[_indexPoint];

        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Ligne entre les cibles
        for (int i = 0; i < _points.Length - 1; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_points[i].position, 
                _points[i + 1].position);
        }

        // Ligne entre l'ennemi et la cible
        if (_cible != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, _cible.position);
        }
    }
#endif
}
