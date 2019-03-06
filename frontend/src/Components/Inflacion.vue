<template>
<search :endpoint="dt" :lngt="4" inputType="number">
    <template v-slot:msg>
      <h4>Búsqueda de inflación por período</h4>
    </template>
    <template v-slot:lbl>
      <i class="fas fa-business-time"></i>
    </template>
  </search>
</template>
<script>
import Search from "./Search.vue";
export default {
  data(){
    return{
      dt: "inflacion?year="
    };
  },
  components:{
    search:Search
  }
  
}
</script>

