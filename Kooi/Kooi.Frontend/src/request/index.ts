import axios from 'axios'
// create axios
const service=axios.create({
    baseURL:"https://localhost:5000",
    timeout:5000,
    headers:{
        "Content-Type":"application/json;charset=utf-8"
    }
})

export default service