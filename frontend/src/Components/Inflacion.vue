<template>
      <div>
    <div class="row">
      <div class="col-sm-8 offset-sm-2">
          <h4>Búsqueda de inflación por período</h4>
          <hr>
          <div class="input-group">
        <div class="input-group-prepend">
          <label for="srch" class="input-group-text"><i class="fas fa-business-time"></i></label>
        </div>
        <input type="number" class="form-control" placeholder="Introduzca el periodo" name="srch" v-model="srch" @keypress.enter="search">
      </div>
      </div>
      
    </div>
    <br>
    <div class="row" v-if="dt">
      <div class="col-sm-8 offset-sm-2">
         <div class="card">
           <div class="card-content">
              <pre>
          <code>
          {{dt}}
          </code>
        </pre>
           </div>
         </div>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
import swal from "sweetalert";
export default {
  data(){
    return{
      srch:"",
      dt: "",
      error: ""
    };
  },
  methods:{
    search(e){
      if(e.target.value.length === 4)
      {
        e.preventDefault();
        axios.get(`http://wspublicosapi.azurewebsites.net/api/inflacion?year=${this.srch}`)
            .then((res)=> this.dt = res.data)
            .catch((e)=> this.error = e.response.data);
      }
    }
  },
  watch:{
    error(val){
      if(val)
        swal({
          title:"Error",
           text: val,
           icon:"error"
        });
        this.error = "";
    }
  }
}
</script>

