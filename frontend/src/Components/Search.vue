<template>
  <div>
    <div class="row">
      <div class="col-sm-8 offset-sm-2">
          <slot name="msg"></slot>
          <hr>
          <div class="input-group">
        <div class="input-group-prepend">
          <label for="srch" class="input-group-text">
              <slot name="lbl"></slot>
          </label>
        </div>
        <input :type="inputType" class="form-control" placeholder="Presione enter para buscar" name="srch" v-model="srch" @keypress.enter="search" @keypress="prevent">
      </div>
      </div>
      
    </div>
    <br>
    <div v-if="process">
      <processing></processing>
    </div>
    <div class="row" v-if="dt && !process">
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
import Processing from "./Processing.vue";
export default {
  data(){
    return{
      srch:"",
      dt: "",
      error: "",
      process: false
    };
  },
  components:{
    processing:Processing
  },
  methods:{
    search(e){
        this.process = true;
        axios.get(`http://wspublicosapi.azurewebsites.net/api/${this.endpoint}${this.srch}`)
            .then((res)=> {
              this.process = false;
              this.dt = res.data;
            })
            .catch((e)=> {
              this.process = false;
              this.error = e.response.data;
            });
      
    },
    prevent(e){
      if(e.target.value.length === this.lngt)
        e.preventDefault();
    }
  },
  props:{
      endpoint:{
          type: String,
          required: true
      },
      lngt:{
        type: Number,
        required: true
      },
      inputType:{
        type:String,
        required:true
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

