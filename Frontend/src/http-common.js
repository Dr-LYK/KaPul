import {CONFIG} from "./config";
import axios from "axios"

const axiosInstance = axios.create(
{
  baseURL: CONFIG.API_URL
});



axiosInstance.interceptors.response.use(
res => {return res;},
err =>
{
  console.log(err);

  if (err.response.status === 401)
  {
    //axios.get(CONFIG.API_URL+"/logout");

    window.location.replace('/login');
  }
  else
    return Promise.reject(err);
});

export const HTTP = axiosInstance;