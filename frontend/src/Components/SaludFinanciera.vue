<template>
    <search inputType="number" :lngt="11" :endpoint="dt">
         <template v-slot:msg>
      <h4>Revisar salud financiera de un cliente por cedula</h4>
    </template>
    <template v-slot:lbl>
      <i class="fas fa-laptop-medical"></i>
    </template>
    </search>
</template>
<script>
 import Search from "./Search.vue";
export default {
   data(){
       return {
           dt:"Crediticio?cedula="
       }
   },
   components:{
       search:Search
   }
}
</script>

