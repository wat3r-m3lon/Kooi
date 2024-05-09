<template>
    <div class="registration-container">
      <div class="card mx-auto pa-12 pb-8">
        <div class="header">Create Account</div>
  
        <input v-model="fullname" class="input-field" type="text" placeholder="Full Name">
        <input v-model="email" class="input-field" type="email" placeholder="Email address">
        <input v-model="password" class="input-field" :type="visible ? 'text' : 'password'" placeholder="Enter your password" @click="visible = !visible">
  
        <select v-model="selectedRole" class="input-field">
          <option v-for="role in Roles" :key="role.value" :value="role.value">
            {{ role.text }}
          </option>
        </select>
  
        <input v-model="networkId" class="input-field" type="text" placeholder="Enter your NetworkId">
  
        <button @click="RegisterUser" class="btn-signup">Sign Up</button>
        <div class="footer-text">
          <router-link class="link" to="/login">
            Already have an account? Log In
          </router-link>
        </div>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref } from "vue";

      const fullname = ref('');
      const email = ref('');
      const password = ref('');
      const selectedRole = ref('');
      const networkId = ref('');
      const visible = ref(false);
  
      const Roles = ref([
        { value: '04597a79-abe0-4bcc-bd43-e4b9d2fbfe23', text: 'Super Admin' },
        { value: '04597a79-abe0-4bcc-bd43-e4b9d2fbfe24', text: 'Admin' },
        { value: '04597a79-abe0-4bcc-bd43-e4b9d2fbfe27', text: 'Standard' },
      ]);
      
     const RegisterUser = async () => {
    var req = {
        fullname: fullname.value,
        email: email.value,
        password: password.value,
        roleId: selectedRole.value,
        networkId: networkId.value
    };

    console.log(req);
    const url = 'https://localhost:5000/register';

    const headers = new Headers({
        Accept: 'application/json',
        'Content-Type': 'application/json'
    });

    try {
        const result = await fetch(url, {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(req)
        });

        if (!result.ok) {
            throw new Error('Network response was not ok');
        }

        const responseData = await result.json();
        console.log(responseData);
    } catch (error) {
        console.error('There was a problem with the fetch operation:');
    }
};
  
  </script>
  
  <style scoped>
  .registration-container {
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  
  .logo {
    max-width: 228px;
  }
  
  .card {
    max-width: 448px;
    padding: 12px 0 8px;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    text-align: center;
  }
  
  .header {
    font-size: 1.125rem;
    margin-bottom: 12px;
  }
  
  .input-field {
    width: 100%;
    padding: 10px;
    margin: 6px 0;
    border: 1px solid #ccc;
    border-radius: 4px;
  }
  
  .btn-signup {
    width: 100%;
    padding: 10px;
    background-color: blue;
    color: white;
    border: none;
    border-radius: 4px;
    margin-top: 8px;
    cursor: pointer;
  }
  
  .footer-text {
    margin-top: 12px;
  }
  
  .link {
    color: blue;
    text-decoration: none;
  }
  </style>
  