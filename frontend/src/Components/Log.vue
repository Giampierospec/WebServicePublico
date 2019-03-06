<template>
<gen-table :list="dt" :objProps="obj" :tableProps="tp">
    <template v-slot:header>
        <h4>Lista llamadas web service</h4>
        <hr/>
    </template>
</gen-table>
</template>
<script>
import GenTable from "./GenTable.vue";
import axios from "axios";
export default {
    data(){
       return{
            dt:[],
        obj:["nombreWS","ip","method","fechaInvocacion"],
        tp:["Nombre Web Service","Ip","Metodo","Fecha Invocacion"]
       };
    },
    components:{
        genTable: GenTable
    },
    mounted(){
        axios.get('http://wspublicosapi.azurewebsites.net/api/Log')
            .then((res)=> this.dt = res.data)
            .catch((e)=> console.log(e.response));
    }
}
</script>
