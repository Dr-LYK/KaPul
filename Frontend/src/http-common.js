import {CONFIG} from "./config";
import axios from "axios"

const axiosInstance = axios.create(
{
  baseURL: CONFIG.API_URL,
  withCredentials: true/*,
    xsrfCookieName: '_csrf'*/
});

axiosInstance.interceptors.response.use(
res => {return res;},
err =>
{
  console.log(err);
  //if (typeof err.reponse === 'undefined')

  //window.location.replace('/error/503');
  if (err.response.status === 401)
  {
    axios.get(CONFIG.API_URL+"/logout");
    window.location.replace('/login');
  }
  //else if (err.response.status === 500)
  //{
  //window.location.replace('/error/500');
  //}
  else
    return Promise.reject(err);
});

export const HTTP = axiosInstance;