const dotNetApiUrl = import.meta.env.VITE_DOTNET_API_URL
const externalApi = import.meta.env.VITE_EXTERNAL_API
const username = import.meta.env.VITE_EXTERNAL_API_USERNAME
const password = import.meta.env.VITE_EXTERNAL_API_PASSWORD

export default {
  async getAllCompanies() {
    try {
      const response = await fetch(`${dotNetApiUrl}/api/company`)
      if (!response.ok) {
        throw new Error('Failed to fetch companies')
      }
      return await response.json()
    } catch (error) {
      console.error('Error fetching companies:', error)
    }
  },

  async findCompany(ide) {
    try {
      const response = await fetch(`${externalApi}/api/v1/company/uid/${ide}`, {
        method: 'GET',
        credentials: 'include',
        redirect: 'follow',
        agent: null,
        headers: {
          Authorization: 'Basic ' + btoa(`${username}:${password}`)
        }
      })
      return await response.json()
    } catch (error) {
      console.error('Error finding company: ', error)
    }
  },

  async addCompany(newCompany) {
    try {
      const response = await fetch(`${dotNetApiUrl}/api/company`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(newCompany)
      })

      if (!response.ok) {
        throw new Error('Failed to add company')
      }

      return await response.json()
    } catch (error) {
      console.error('Error adding company:', error)
      throw error
    }
  },

  async deleteCompany(id) {
    try {
      const response = await fetch(`${dotNetApiUrl}/api/company/${id}`, {
        method: 'DELETE'
      })
      return await response
    } catch (error) {
      console.error('Error deleting company:', error)
      throw error
    }
  }
}
