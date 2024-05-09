<template>
    <v-app>
      <!-- Header (H) -->
      <v-app-bar app color="indigo" dark>
        <v-toolbar-title>
          <!-- User Avatar -->
          <v-avatar size="32">
            <img src="https://randomuser.me/api/portraits/women/75.jpg" alt="User Avatar">
          </v-avatar>
        </v-toolbar-title>
      </v-app-bar>
  
      <!-- Layout Container -->
      <v-container fluid>
        <v-row>
          <!-- Left Sidebar (L) -->
          <v-col cols="3">
            <v-navigation-drawer permanent>
              <v-list >
  
                <v-list-group value="Basic Tool-Tips">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="Basic Tool-Tips"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="All Basic Tool-tips"></v-list-item>
                  <v-list-item title="Add New"></v-list-item>
                </v-list-group>
                
                <!-- ... Other list groups ... -->
                <v-list-group value="Rich Tool-Tips">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="Rich Tool-Tips"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="All Rich Tool-tips"></v-list-item>
                  <v-list-item title="Add New"></v-list-item>
                  <v-list-item title="Template Management"></v-list-item>
                </v-list-group>

                <v-list-group value="Guided Tour">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="Guided Tour"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="All Guided Tour"></v-list-item>
                  <v-list-item title="Add New"></v-list-item>
                  <v-list-item title="Template Management"></v-list-item>
                </v-list-group>

                <v-list-group value="Notification">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="Notification"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="All Notification"></v-list-item>
                  <v-list-item title="Add New"></v-list-item>
                  <v-list-item title="Template Management"></v-list-item>
                </v-list-group>

                <v-list-group value="Slides Management">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="Slides Management"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="All Slides"></v-list-item>
                  <v-list-item title="Add New"></v-list-item>
                </v-list-group>

                <v-list-group value="Seeting">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="Seeting"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="Appearance"></v-list-item>
                </v-list-group>

                <v-list-group value="User Management">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="User Management"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="All User Group"></v-list-item>
                  <v-list-item title="Add New User"></v-list-item>
                  <v-list-item title="Import User Group"></v-list-item>
                </v-list-group>

                <v-list-group value="View & Analyze">
                  <template v-slot:activator="{ props }">
                    <v-list-item
                      v-bind="props"
                      title="View & Analyze"
                    ></v-list-item>
                  </template>
                  
                  <v-list-item title="By Content Type"></v-list-item>
                  <v-list-item title="By User Group"></v-list-item>
                  <v-list-item title="By Timeline"></v-list-item>
                </v-list-group>

              </v-list>

              
            </v-navigation-drawer>
          </v-col>
  
          <!-- Main Content (M) -->
          <v-col cols="4">
            <p>123456789</p>
            <!-- Your main content here -->
          </v-col>
        </v-row>
      </v-container>
    </v-app>
  </template>
  
  <script>
  export default {
    data: () => ({
      open: ['Basic Tool-Tips'],
      // ... Your other data properties ...
    }),
  }
  </script>
  