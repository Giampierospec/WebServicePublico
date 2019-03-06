<template>
  <search :endpoint="dt" :lngt="3" inputType="text">
    <template v-slot:msg>
      <h4>Utilice un codigo de moneda para ver su tasa de cambio con respecto al peso</h4>
    </template>
    <template v-slot:lbl>
      <i class="fas fa-money-bill"></i>
    </template>
  </search>
</template>

<script>
import Search from "./Search.vue";
import axios from "axios";
import swal from "sweetalert";
export default {
  data(){
    return{
      dt: "change?cod="
    };
  },
  components:{
    search:Search
  }
}
</script>

