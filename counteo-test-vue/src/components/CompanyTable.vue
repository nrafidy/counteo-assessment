<script setup>
    import CompanyService from '../services/CompanyService';
import { store } from '../store/store.js'
</script>

<template>
    <table class="w-full border">
      <thead>
        <tr>
          <th class="border p-2 font-semibold">Numero IDE</th>
          <th class="border p-2 font-semibold">Nom de la societe</th>
          <th class="border p-2 font-semibold">Adresse</th>
          <th class="border p-2 font-semibold">Forme juridique</th>
          <th class="border p-2 font-semibold">Siege</th>
          <th class="border p-2 font-semibold">Date de derniere modification</th>
          <th class="border p-2 font-semibold">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="company in store.companies" :key="company.id">
          <td class="border p-2">{{ company.ide }}</td>
          <td class="border p-2">{{ company.nom }}</td>
          <td class="border p-2">{{ company.adresse }}</td>
          <td class="border p-2">{{ company.formeJuridique }}</td>
          <td class="border p-2">{{ company.siege }}</td>
          <td class="border p-2 text-center">{{ company.dateDerniereModification }}</td>
          <td class="border p-2">
            <button @click="deleteCompany(company.id)" class="text-red-500 text-center">
              Supprimer
            </button>
          </td>
        </tr>
      </tbody>
    </table>
</template>

<script>
    export default {
        methods:{
            async deleteCompany(id) {
                try {
                    await CompanyService.deleteCompany(id)
                    store.companies = store.companies.filter(company => company.id !== id);
                }
                catch (error) {
                    console.error("Error deleting company:", error);
                }
            },
        }
    };
</script>