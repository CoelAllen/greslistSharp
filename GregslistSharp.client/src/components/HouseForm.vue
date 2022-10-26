<template>
  <form class="component" @submit.prevent="handleSubmit">
    <h4>Make ad</h4>
    <input type="url" class="form-control" v-model="editable.imgUrl">
    <label for="floors">Floors</label>
    <input name="floors" type="number" class="form-control" v-model="editable.floors">
    <label for="bedrooms">Bedrooms</label>
    <input name="bedrooms" type="number" class="form-control" v-model="editable.bedroom">
    <label for="year">Year</label>
    <input name="year" type="number" class="form-control" v-model="editable.year">
    <textarea type="text" class="form-control" v-model="editable.description" placeholder="Description" cols="30"
      rows="10"></textarea>
    <button class="btn btn-primary" type="submit">Add House</button>
  </form>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { housesService } from '../services/HousesService.js'

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async handleSubmit() {
        try {
          await housesService.createAd(editable.value)
          editable = {}
        } catch (error) {
          Pop.error(error, '[creating house ad]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>