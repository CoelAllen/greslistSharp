<template>
  <HouseForm />

  <div>
    <div v-for="h in houses">
      <img :src="h.imgUrl" height="250" alt="">
      <h3>a {{  c.floors  }} floor, {{  c.bedrooms  }} home built in {{  c.year  }} </h3>




    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';
import HouseForm from '../components/HouseForm.vue';
import { housesService } from '../services/HousesService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    async function getHouses() {
      try {
        await housesService.getHouses()
      } catch (error) {
        Pop.error(error, "[getting houses]")
      }
    }
    onMounted(() => {
      getHouses()
    })
    return {
      houses: computed(() => AppState.houses)
    };
  },
  components: { HouseForm }
}
</script>

<style scoped lang="scss">

</style>
