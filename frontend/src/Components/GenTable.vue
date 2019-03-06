<template>
    <div class="row">
        <div class="col-sm-8 offset-sm-2">
            <slot name="header"></slot>
            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th v-for="item in tableProps">{{item}}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="obj in paginatedData">
                        <td v-for="pr in objProps">{{obj[pr]}}</td>
                    </tr>
                </tbody>
            </table>
            <button @click="prevPage" class="btn btn-default" :disabled="pageNumber === 0"><i class="far fa-caret-square-left"></i></button>
            <button @click="nextPage" class="btn btn-default" :disabled="pageNumber >= (pageCount -1)"><i class="far fa-caret-square-right"></i></button>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            pageNumber:0
        };
    },
    computed:{
        pageCount(){
            let l = this.list.length,
            s = this.maxSize;
            return Math.ceil(l/s);

        },
        paginatedData(){
            const start = this.pageNumber * this.maxSize,
            end = start +this.maxSize;
            return this.list.slice(start,end);
        }
    },
    methods:{
        nextPage(){
            this.pageNumber++;
        },
        prevPage(){
            this.pageNumber--;
        }
    },
    props:{
        list:{
            type:Array,
            required:true
        },
        maxSize:{
            type:Number,
            default: 5,
            required: false
        },
        objProps:{
            type:Array,
            required:true
        },
        tableProps:{
            type:Array,
            required:true
        }
    }
}
</script>

