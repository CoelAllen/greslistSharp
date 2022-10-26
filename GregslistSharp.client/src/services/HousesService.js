import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js"

class HousesService {
async createAd(adData){
  const res = await api.post('api/houses', adData)
  AppState.classifieds.push(res.data)
}
async getHouses(){
  const res = await api.get('api/houses')
  AppState.houses = res.data
}
}
export const housesService = new HousesService()