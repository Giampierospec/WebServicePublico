<template>
<div>
<br>
<div class="row">
    <div class="col-sm-8 offset-sm-2">
        <h4>Contabilización llamada a servicios</h4>
        <ul class="list-group list-group-horizontal-sm">
          <li class="list-group-item" v-for="(v,k) in resultFilter">
              {{k}}
              <span class="badge badge-primary badge-pill">{{v.length}}</span>
          </li>
</ul>
    </div>
</div>
<gen-table :list="dt" :objProps="obj" :tableProps="tp">
    <template v-slot:header>
        <h4>Lista llamadas web service</h4>
        <hr/>
    </template>
</gen-table>
</div>
</template>
<script>
import GenTable from "./GenTable.vue";
import axios from "axios";
import _ from "lodash";
export default {
    data(){
       return{
            dt:[],
            resultFilter:"",
        obj:["nombreWS","ip","method","fechaInvocacion"],
        tp:["Nombre Web Service","Ip","Metodo","Fecha Invocacion"]
       };
    },
    methods:{
        getData(){
               axios.get('http://wspublicosapi.azurewebsites.net/api/Log')
            .then((res)=> {
                this.dt = res.data;
                this.resultFilter = _.groupBy(this.dt,"nombreWS");
            })
            .catch((e)=> console.log(e.response));
        }
    },
    components:{
        genTable: GenTable
    },
    mounted(){
     this.getData();
     
    }
}
</script>
