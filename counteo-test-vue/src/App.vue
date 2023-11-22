<script setup>
// import { RouterLink, RouterView } from 'vue-router'
import Searchbar from './components/Searchbar.vue';
import CompanyTable from './components/CompanyTable.vue';
import './index.css'
import { store } from './store/store.js'
import CompanyService from './services/CompanyService'

</script>

<template>
  <div class="container w-full">
    <h1 class="text-2xl font-bold mb-4">Societe a suivre</h1>

    <!-- Search Bar -->
    <Searchbar />

    <!-- Table -->
    <company-table></company-table>
  </div>
</template>

<script>
export default {
    created() {
        this.fetchCompanies();
    },
    methods: {
      async fetchCompanies() {
          try {
              const response = await CompanyService.getAllCompanies();
              store.companies = response;
          }
          catch (error) {
              console.error("Error fetching companies:", error);
          }
      },
    },
    components:{
      Searchbar,
      CompanyTable
    }
};
</script>

