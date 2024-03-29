import React, { Component } from 'react';
import decode from 'jwt-decode';
import {Redirect } from 'react-router-dom';
export default class AuthService {
    // Initializing important variables
    constructor(domain) {
        this.domain = domain || 'https://localhost:44330/api/Users' // API server domain
      this.fetch = this.fetch.bind(this); // React binding stuff
      this.login = this.login.bind(this);
      this.register = this.register.bind(this);
      this.getProfile = this.getProfile.bind(this);
    }

    login(username, password) {
        // Get a token from api server using the fetch api
        return fetch(`${this.domain}/Login`, {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                username,
                password
            })
        })
        .then(response => response.json()).then(res => {
            this.setToken(res.token, res.username); // Setting the token in localStorages
            return Promise.resolve(res);
            })
        .catch(err => {
            alert(err);
          });

    }

    register(username, password) {
        // Get a token from api server using the fetch api
        return fetch(`${this.domain}/Register`, {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                username,
                password
            })
        })
        .then(response => response.json()).then(res => {
            if(res.token !== null)
            {
                this.setToken(res.token); // Setting the token in localStorages
            }
            if(res.message === null)
            {
                res.message = "Something went wrong."
            }
            return Promise.resolve(res);
            
            })
        .catch(err => {
            alert(err);
          });

    }


    loggedIn() {
        // Checks if there is a saved token and it's still valid
        const token = this.getToken() // GEtting token from localstorage
        return !!token && !this.isTokenExpired(token) // handwaiving here
    }

    isTokenExpired(token) {
        try {
            const decoded = decode(token);
            if (decoded.exp < Date.now() / 1000) { // Checking if token is expired. N
                return true;
            }
            else
                return false;
        }
        catch (err) {
            return false;
        }
    }

    setToken(idToken, idUser) {
        // Saves user token to localStorage
        localStorage.setItem('id_token', idToken)
        //Saves username to localstorage
        localStorage.setItem('id_user', idUser)
    }

    getToken() {
        // Retrieves the user token from localStorage
        return localStorage.getItem('id_token')
    }

    getUserId()
    {
        return localStorage.getItem('id_user');
    }

    logout() {
        // Clear user token and profile data from localStorage
        localStorage.removeItem('id_token');
        localStorage.removeItem('id_user');
        window.location.reload();
    }

    getProfile() {
        // Using jwt-decode npm package to decode the token
        return decode(this.getToken());
    }


    fetch(url, options) {
        // performs api calls sending the required authentication headers
        const headers = {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }

        // Setting Authorization header
        // Authorization: Bearer xxxxxxx.xxxxxxxx.xxxxxx
        if (this.loggedIn()) {
            headers['Authorization'] = 'Bearer ' + this.getToken()
        }

        return fetch(url, {
            headers,
            ...options
        })
            .then(this._checkStatus)
            .then(response => response.json())
    }

    _checkStatus(response) {
        // raises an error in case response status is not a success
        if (response.status >= 200 && response.status < 300) { // Success status lies between 200 to 300
            return response
        } else {
            var error = new Error(response.statusText)
            error.response = response
            throw error
        }
    }
}