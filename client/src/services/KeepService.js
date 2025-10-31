import { Keep } from "@/models/Keep.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"

export class KeepService {
    async getActiveKeep(keepId) {
        const response = await api.get(`api/keeps/${keepId}`)
        console.log("fetching active keep...", response.data)
        AppState.activeKeep = new Keep(response.data)
    }
    async getKeeps() {
        const response = await api.get('api/keeps')
        const allKeeps = response.data.map(keeps => new Keep(keeps))
        AppState.keeps = allKeeps
    }

}
export const keepService = new KeepService()
