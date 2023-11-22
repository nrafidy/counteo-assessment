<script setup>
    import { store } from '../store/store.js'
    import CompanyService from '../services/CompanyService';
</script>

<template>
    <div class="flex items-center mb-4">
    <input
      v-model="searchQuery"
      class="w-full p-2 border rounded mr-2"
      placeholder="Rechercher"
    />
    <button @click="addCompany" class="bg-blue-500 text-white px-4 py-2 rounded">
      Ajouter
    </button>
  </div>
</template>

<script>

export default {
    data() {
        return {
            searchQuery: "",
        }
    },
    methods: {
        async addCompany() {
            try {
                const cleanedQuery = this.searchQuery.replace(/[-.]/g, '');
                const data = await CompanyService.findCompany(cleanedQuery);
                
                if (data.length === 0) {
                    alert('Societe introuvable.');
                } else {
                    const comp = {
                        id: 2,
                        ide: data[0].uid,
                        nom: data[0].name,
                        adresse: data[0].address.houseNumber + ' ' + data[0].address.street + ', ' +  data[0].address.city + ', ' + data[0].address.swissZipCode,
                        formeJuridique: data[0].legalForm.shortName.fr,
                        siege: data[0].legalSeat,
                        dateDerniereModification: data[0].sogcDate,
                    };

                    const addedComp = await CompanyService.addCompany(comp)

                    store.companies.push(addedComp);

                }
            } catch (error) {
                console.error('Error searching companies:', error);
            }
        },
    }
}
</script>