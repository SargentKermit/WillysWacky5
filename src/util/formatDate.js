import dayjs from "dayjs";
import relativeTime from "dayjs/plugin/relativeTime";

dayjs.extend(relativeTime);

function time(createAt){

    if (createAt >= Date.now() - (1 * 7 * 24 * 60 * 60 * 1000)){
        return (dayjs(createAt).fromNow())
    }
    else{
        return (dayjs(createAt).format("h:mm a on M/D/YYYY"))
    }
}
export default time;