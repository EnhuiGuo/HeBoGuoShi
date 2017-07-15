//$(document).ready(function () {

//    deleteImage = function (image) {

//        $.confirm({
//            title: "要删除么？",
//            content: "删除",
//            buttons: {
//                confirm: function () {
//                    var id = $(image).data("imageId");
//                    $.ajax({
//                        type: "POST",
//                        url: "/OwnerProduct/RemoveImage",
//                        data: { "id": id },
//                        success: function (result) {
//                            if (result.Success) {
//                                updateImagesDetail();
//                            }
//                        }
//                    });
//                },
//                cancel: function () {

//                },
//            }
//        });
//    }

//    function updateImagesDetail(e) {
//        $.ajax({
//            type: "GET",
//            url: "/OwnerProduct/_ProductImagesDetail",
//            data: { "id": productId },
//            success: function (result) {
//                console.log(result);
//                $('#imagesDetail').html(result);
//            }
//        });
//    }
//})