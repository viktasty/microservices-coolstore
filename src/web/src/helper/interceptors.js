import axios from 'axios'
import store from '../stores'
import router from '../routes'

export default function setup() {
    axios.interceptors.request.use(
        function(config) {
            const token = store.getters.accessToken
            if (token) {
                config.headers.Authorization = `Bearer ${token}`
            }
            return config
        },
        function(err) {
            return Promise.reject(err)
        }
    )

    axios.interceptors.response.use(
        function(response) {
            return response
        },
        function(error) {
            if (401 === error.response.status) {
                debugger;
            } else {
                return Promise.reject(error)
            }
        }
    )
}
