import decode from 'jwt-decode';
import AuthService from '../services/AuthService';

export default class PhotoService {
    // Initializing important variables
    constructor(domain, props) {
        this.domain = domain || 'https://localhost:44320/api/PhotoAlbum' // API server domain
        this.Auth = new AuthService();
        this.fetch = this.Auth.fetch.bind(this) // React binding stuff
    }
    
    getAlbumById(Guid)
    {
        return fetch(`${this.domain}/GetById`,  {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Guid
            })
        })
        .then(response => response.json()).then(res => {
            var test = res;
            var promise = Promise.resolve(res);
            return test;
            })
        .catch(err => {
            alert(err);
          });

    }

    addAlbum(User, Model) {
        // Get a token from api server using the fetch api
        return fetch(`${this.domain}/Create`,  {
            method: 'POST',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                User,
                Model
            })
        })
        .then(response => response.json()).then(res => {
            var test = res;
            var promise = Promise.resolve(res);
            return test;
            })
        .catch(err => {
            alert(err);
          });

    }

    editAlbum(User, Model, Guid) {

        // Get a token from api server using the fetch api
        return fetch(`${this.domain}/Edit`,  {
            method: 'PUT',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                User,
                Model,
                Guid
            })
        })
        .then(res => {
            if(res.ok)
            {
                var test = res;
                var promise = Promise.resolve(res);
                return test;
            }else if(res.message != null)
            {
                return res.message;//Do something with the error
            }
           
            })
        .catch(err => {
            alert(err);
          });

    }

    setPhotoAlbumId(id) {
        // Saves user token to localStorage
        localStorage.setItem('current_album_token', id)
    }

    getPhotoAlbumId() {
        // Retrieves the user token from localStorage
        return localStorage.getItem('current_album_token')
    }

    
    delete(Guid) {
        // Get a token from api server using the fetch api
        return fetch(`${this.domain}/Delete`, {
            method: 'DELETE',
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                Guid
            })
        })
        .then(response => response.json()).then(res => {
            //this.props.history.push('/photoAlbums');
            return Promise.resolve(res);
            })
        .catch(err => {
            alert(err);
          });

    }
}