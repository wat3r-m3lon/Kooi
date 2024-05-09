<template>
  <div>
    <v-card
      class="mx-auto pa-12 pb-8"
      elevation="8"
      max-width="448"
      rounded="lg"
    >
      <div class="text-subtitle-1 text-medium-emphasis">Login</div>

      <v-text-field
        v-model="email"
        density="compact"
        placeholder="Email address"
        prepend-inner-icon="mdi-email-outline"
        variant="outlined"
      ></v-text-field>

      <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
        Password
        <a
          class="text-caption text-decoration-none text-blue"
          href="#"
          rel="noopener noreferrer"
          target="_blank"
        >
          Forgot login password?
        </a>
      </div>

      <v-text-field
        v-model="password"
        :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
        :type="visible ? 'text' : 'password'"
        density="compact"
        placeholder="Enter your password"
        prepend-inner-icon="mdi-lock-outline"
        variant="outlined"
        @click:append-inner="toggleVisibility"
      ></v-text-field>

      <v-btn
        @click="loginUser"
        block
        class="mb-8"
        color="blue"
        size="large"
        variant="tonal"
      >
        Log In
      </v-btn>
    </v-card>
  </div>
</template>
<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router"; // Import useRouter

const email = ref('');
const password = ref('');
const visible = ref(false);
const router = useRouter(); // Initialize router

const toggleVisibility = () => {
  visible.value = !visible.value;
}

const loginUser = async () => {
  // Existing code for handling login
  const req = {
    email: email.value,
    password: password.value,
  };

  const url = 'https://localhost:5000/login';
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
    // Redirect to Admin page upon successful login
    router.push('/admin');
  } catch (error) {
    console.error('There was a problem with the fetch operation:');
  }
};
</script>




