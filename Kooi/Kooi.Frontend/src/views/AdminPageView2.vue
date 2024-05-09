<template>
  <v-app>
    <!-- Side Drawer -->
    <v-navigation-drawer app v-model="drawer">
      <v-list-item to="/">
        <v-list-item-content>
          <v-list-item-title class="title">
            Admin Page
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-divider></v-divider>
      <v-list dense>
        <v-list-item @click="selectedItem = 'Dashboard'" title="Dashboard">

        </v-list-item>
        <v-list-item @click="selectedItem = 'BasicToolTips'" title="Basic Tool-Tips">

        </v-list-item>
        <!-- More list items here -->
        <v-list-item @click="selectedItem = 'GuidedTour'" title="Guided Tour">

        </v-list-item>
        
        <v-list-item @click="selectedItem = 'Notification'" title="Notification">

        </v-list-item>
        <v-list-item @click="selectedItem = 'SitesManagement'" title="Sites Management">

        </v-list-item>
        <v-list-item @click="selectedItem = 'Seetings'" title="Seetings">

        </v-list-item>
        <v-list-item @click="selectedItem = 'UserManagement'" title="User Management">

        </v-list-item>
        <v-list-item @click="selectedItem = 'ViewAnalyze'" title="View&Analyze">

        </v-list-item>                
      </v-list>
    </v-navigation-drawer>

    <!-- Top Navigation -->
    <v-app-bar app color="blue" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>
        <v-avatar size="32">
          <img src="https://randomuser.me/api/portraits/women/75.jpg" alt="User Avatar">
        </v-avatar>
      </v-toolbar-title>
    </v-app-bar>

    <!-- Main Content -->
    <v-main>
      <v-container fluid>
        <div v-if="selectedItem === 'BasicToolTips'">
          <!-- Content for Basic Tool-Tips -->
          <p>This is the content for Basic Tool-Tips.</p>
        </div>
        <div v-if="selectedItem === 'RichToolTips'">
          <!-- Content for Rich Tool-Tips -->
          <p>This is the content for Rich Tool-Tips.</p>
        </div>
    <div v-if="selectedItem === 'UserManagement'">
      <p>This is the content for User Management.</p>
      <!-- Register Button -->
      <v-btn color="primary" @click="goToRegister">Register</v-btn>
    </div>
        <!-- More content divs here based on other list items -->
      </v-container>
    </v-main>

    <!-- Footer -->
    <v-footer app class="justify-center">
      Footer Content
    </v-footer>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const drawer = ref(true);
const dialog = ref(false);
const selectedItem = ref('');

const router = useRouter();

const goToRegister = () => {
  router.push('/register');
};
</script>

<style scoped>
/* Add your styles here */
</style>
