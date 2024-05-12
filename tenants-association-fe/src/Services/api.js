import axios from "axios";

const axiosClient = axios.create({
  baseURL: `https://localhost:7066/api/`,
});

axiosClient.interceptors.request.use(function (config) {
  let token = localStorage.getItem("token");
  if (token === null) {
    token = sessionStorage.getItem("token");
  }
  config.headers.Authorization = token ? `Bearer ${token}` : "";
  return config;
});

export default axiosClient;
